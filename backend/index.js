const mysql = require('mysql');
const cors = require('cors');
const express = require('express');
const bcrypt = require("bcrypt");
const JWT = require("jsonwebtoken");
const app = express();
app.use(cors());
require("dotenv").config();
// Create a connection object
const connection = mysql.createConnection({
  host: 'localhost',     // Hostname of your database server
  user: 'root',          // MySQL username
  password: '',          // MySQL password
  database: 'vizsga'  // Name of your database
});
const PORT = 8898; // Choose any available port number
// Connect to the database
connection.connect((error) => {
  if (error) throw error;
  console.log('A szerver szalad');
  console.log(`A szerver portja: ${PORT}`)
});
app.use(express.json());
// Start the server
app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});
// Define API routes
app.get('/a', (req, res) => {
  res.send('Hello from the backend server! A szerver szalad!');
});

app.get('/ar', (req, res) => {
  const searchQuery = req.query.query;
  connection.query('SELECT * FROM arkategoria WHERE kategoria = ?', [searchQuery], (error, results) => {
    if (error) throw error;
    res.json(results);
  });
});

app.get('/kategoria', (req, res) => {
  // Use connection.query to interact with the database
  const searchQuery = req.query.query;
  connection.query('SELECT * FROM auto WHERE arkategoria = ?', [searchQuery], (error, results) => {
    if (error) throw error;
    res.json(results);
  });
});

app.get('/datum', (req, res) => {
  connection.query("SELECT kezdonap, zaronap, autoazo FROM nyilvantartas", (error, results) => {
    if (error) throw error;
    res.json(results);
  });
})

app.post("/foglalas", async (req, res) => {
  const { kezdo, zaro, autoAzo, nev, rentId,berletDij,osszeg } = req.body;
  //Frontend from encoded token name property 
  const getUgyfelAzo = `SELECT ugyfelazo FROM ugyfel WHERE nev='${nev}'`
  const insertFoglalas = `INSERT into nyilvantartas (autoazo, kezdonap, zaronap,ugyfelazo, berlesazo,berletidij,osszeg) VALUES (?, ?, ?, ?, ?,?,?)`;
  connection.query(getUgyfelAzo, async (error, results) => {
    if (error) {
      res.status(500).send("Server error");
    }
    else if (results.length == 0) {
      res.status(414).send("Nincs ilyen felhasználó");
      console.log('Felhasználó nem található az adatbázisban')
    } else if (kezdo > zaro) {
      res.status(402).send("Kezdőnap nem lehet később a zárónapnál");
    }
    else {
      //Get ugyfelAzo from the tokens name after finding its azo value in sql
      const user = results[0].ugyfelazo;
      connection.query(insertFoglalas,
        //set user to insert azo to database
        [autoAzo, kezdo, zaro, user, rentId,berletDij,osszeg],
        (error, results) => {
          if (error) {
            res.status(500).send("Server error");
            console.log(error)
            console.log(res.json())
            console.log(res.data)
          } else {
            res.status(200).json(results);
            console.log('Sikeres foglalás!')
            console.log(results)
          }
        }
      )
    }
  })
})

app.post("/login", async (req, res) => {
  const { email, jelszo } = req.body;
  function validateEmail(email) {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
  }
  if (!validateEmail(email)) {
    res.status(404).send("Invalid email address");
    return;
  }
  const checkEmail = `SELECT * FROM ugyfel WHERE email = '${email}'`;
  connection.query(checkEmail, async (error, results) => {
    if (error) {
      res.status(500).send("Server error");
    } else if (results.length == 0) {
      res.status(410).send("Hibás e-mail cím vagy jelszó");
      console.log('Sikertelen belépés')
    } else {

      const user = results[0];
      const passwordMatch = await bcrypt.compare(jelszo, user.jelszo)
      if (passwordMatch) {
        const accessToken = await JWT.sign(
          { name: user.nev },
          process.env.ACCESS_TOKEN_SECRET,
          { expiresIn: "1000s" }
        );
        res.json({ accessToken });
        console.log('Sikeres belépés')
      } else {
        res.status(408).send("Hibás e-mail cím vagy jelszó");
        console.log('Sikertelen belépés')
      }
    }
  });
});

app.post("/user/register", async (req, res) => {
  const { nev, irsz, telep, cim, email, tel, jelszo } = req.body;
  const bcryptpass = await bcrypt.genSalt(8);
  const hashedPassword = await bcrypt.hash(jelszo, bcryptpass);

  function validateEmail(email) {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
  }

  if (!validateEmail(email)) {
    res.status(404).send("Invalid email address");
    return;
  }

  const checkEmail = `SELECT * FROM ugyfel WHERE email = '${email}'`;
  connection.query(checkEmail, (error, results) => {
    if (error) {
      res.status(500).send("Server error");
    } else if (results.length > 0) {
      res.status(410).send("Email already exists");
    } else {
      const checkName = `SELECT * from ugyfel WHERE nev='${nev}'`;
      connection.query(checkName, (error, results) => {
        if (error) {
          res.status(500).send("Server error");
        } else if (results.length > 0) {
          res.status(401).send("Username already exists");
        } else {
          const insertUser = `INSERT INTO ugyfel (nev, iranyitoszam, telepules, cim, email, telefon, jelszo) VALUES (?, ?, ?, ?, ?, ?, ?)`;
          connection.query(
            insertUser,
            [nev, irsz, telep, cim, email, tel, hashedPassword],
            (error, results) => {
              if (error) {
                res.status(500).send("Server error");
              } else {
                const accessToken = JWT.sign(
                  {},
                  process.env.ACCESS_TOKEN_SECRET,
                  { expiresIn: "600s" }
                );
                res.status(200).json({ accessToken });
                console.log("Sikeres regisztráció");
              }
            }
          );
        }
      });
    }
  });
});