import React from 'react'
import Header from './Header'
import '../styles/Styles.css'
import { useState, useEffect, useContext } from 'react'
import gearbox from '../kepek/gearbox.jpg'
import calendar from '../kepek/calendar.jpg'
import seat from '../kepek/seat.png'
import briefcase from '../kepek/briefcase.jpg'
import gaspump from '../kepek/gaspump.jpg'
import gps from "../kepek/gps.jpg"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import jwt_decode from 'jwt-decode';
import { useNavigate } from 'react-router-dom'
import { useForm } from 'react-hook-form';
import { format, addDays, getDaysInMonth, addMonths } from 'date-fns';
import CardContext from './context/CardContext'
import Spinner from './Spinner'

function Autok({ prop }) {
  const [loading, setLoading] = useState(true);
  const { formatDate, handleClick, generateRandomTicketNumber } = useContext(CardContext);
  const navigate = useNavigate();
  const { reset } = useForm()
  const isLoggedIn = sessionStorage.getItem('accessToken');
  const currentDate = new Date();
  const minStartDate = format(currentDate, 'yyyy-MM-dd')
  const minEndDate = format(currentDate, 'yyyy-MM-dd')
  const maxStartDate = addDays(currentDate, 30);
  const maxStartDateForm = format(maxStartDate, 'yyyy-MM-dd');
  const maxEndDate = addDays(currentDate, 30)
  const maxEndDateForm = format(maxEndDate, 'yyyy-MM-dd');
  const maxStartString = maxStartDate.toISOString().slice(0, 10);
  const [open, setOpen] = useState(false);
  const [flippedCardIndex, setFlippedCardIndex] = useState(null);
  const [autok, setAutok] = useState([]);
  const [berlesek, setBerlesek] = useState([])
  const [cardStates, setCardStates] = useState({});
  const [arak, setArak] = useState();
  const [berlesAr, setBerlesAr] = useState()
  const [elerDates, setElerDates] = useState([])
  const [dates, setDates] = useState({
    startDate: "",
    endDate: ""
  })

  const currentDate2 = new Date();

  // Get the number of days in the current month
  const currentMonthDays = getDaysInMonth(currentDate2);

  // Get the number of days in the next month
  const nextMonthDate = addMonths(currentDate2, 1);
  const nextMonthDays = getDaysInMonth(nextMonthDate);




  function handleVisszaClick(index) {
    //a parancs nem hajtódik végre ha másik kártya loginclick functionjét hívjuk meg
    if (cardStates[index] == true) {
      setCardStates(prev => ({ ...prev, [index]: false }));
      reset()
      setDates({ startDate: "", endDate: "" });
      setElerDates()
      setOpen(false)
      // Update the flipped card index 
      setFlippedCardIndex(null);
    }
  }

  function test (num1,num2) {
    return num1+num2
  }

  function logInClick(index) {
    if (isLoggedIn) {

      if (flippedCardIndex === index) {
        // Clicked on the same card, flip it back
        setFlippedCardIndex(index);
      }
      // Flip the new card
      else if (flippedCardIndex == null) {
        setCardStates(prev => ({ ...prev, [index]: true }));
        // Update the flipped card index 
        setFlippedCardIndex(index);
      }
      if (flippedCardIndex != null && flippedCardIndex != index) {
        toast.warning('Előbb zárja be a megnyitott kártyáját!', { position: toast.POSITION.BOTTOM_RIGHT })
      }
    }
    else {

      toast.warning('A foglaláshoz bejelentkezés szükséges', { position: toast.POSITION.BOTTOM_RIGHT })
    }
  }

  function handleDates(event, index) {
    const newDates = { ...dates };
    newDates[event.target.name] = event.target.value;
    setDates(newDates);
  }

  useEffect(() => {
    if (dates.startDate != "" && dates.endDate != "" && dates.startDate <= dates.endDate) {
      const milliseconds1 = new Date(dates.startDate).getTime();
      const milliseconds2 = new Date(dates.endDate).getTime();
      const milliseconds = milliseconds2 - milliseconds1 + 86400000;
      const nap = milliseconds / 24 / 60 / 60 / 1000;
      setBerlesAr(nap)
    } else
      setBerlesAr(0)
  }, [dates])

  function elerheto(index) {
    const simplifiedDates = [];
    var elerhetoDates = [];
    const today = new Date();
    const endDate = new Date(today.getTime() + 30 * 24 * 60 * 60 * 1000);
    const azo = autok[index].azo;
    const allDaysList = [];
    const rangeDatesList = [];
    while (today <= endDate) {
      //nap listához adása
      allDaysList.push(formatDate(today));
      //nap növelése 1-el
      today.setDate(today.getDate() + 1);
    }
    //Adatbázisból fetchelt dátumok listához adása
    berlesek.forEach(berles => {
      if (berles.autoazo === azo) {
        const startDate = new Date(berles.kezdonap);
        const endDate = new Date(berles.zaronap);
        const dateRange = [];
        const currentDate = new Date(startDate);
        while (currentDate <= endDate) {
          dateRange.push(formatDate(currentDate));
          currentDate.setDate(currentDate.getDate() + 1);
        }
        rangeDatesList.push(...dateRange);
      }
    });
    //Dátumok kiválasztása és új listához adása, melyek nem szerepelnek mindkét listában
    elerhetoDates = allDaysList.filter(date => !rangeDatesList.includes(date));
    //Szerepel e régebbi dátum a listában 
    const hasOlderDates = elerhetoDates.some(date => new Date(date) < new Date(today.getTime() - 1 * 24 * 60 * 60 * 1000));
    //Lista egyszűsített megjelenítése
    if (elerhetoDates.length == 0 || !hasOlderDates) {
      //Töröljük a lista tartalmát hogy ne jelenjen meg üres doboz amikor a szabad időpontokra kattintunk
      setElerDates()
      return toast.warning(<div>A gépjármű bérelhető időpontjai {maxStartString}-ig beteltek!<br />Egyéb időpont foglalásához vegye fel velünk a kapcsolatot!</div>, { position: toast.POSITION.BOTTOM_RIGHT })
    }
    let startDate = new Date(elerhetoDates[0]);
    let endDate2 = startDate;
    for (let i = 1; i < elerhetoDates.length; i++) {
      const currentDate = new Date(elerhetoDates[i]);
      if (currentDate - endDate2 === 86400000) { //különbség = 1 nap
        endDate2 = currentDate;
      } else {
        if (startDate.getTime() === endDate2.getTime()) {
          simplifiedDates.push(`(${startDate.toISOString().slice(0, 10)} - ${endDate2.toISOString().slice(0, 10)})\n`);
        } else {
          simplifiedDates.push(
            `(${startDate.toISOString().slice(0, 10)} - ${endDate2.toISOString().slice(0, 10)})\n`
          );
        }
        startDate = currentDate;
        endDate2 = currentDate;
      }
    }
    if (startDate.getTime() === endDate2.getTime()) {
      simplifiedDates.push(`(${startDate.toISOString().slice(0, 10)} - ${endDate2.toISOString().slice(0, 10)})`);
    } else {
      simplifiedDates.push(
        `(${startDate.toISOString().slice(0, 10)} - ${endDate2.toISOString().slice(0, 10)})`
      );
    }
    setElerDates(simplifiedDates);
    return simplifiedDates
  }
  //Dátumok összehasonlításához formázás metódus
  const submitClick = async (event, index) => {
    event.preventDefault();
    const ticketNumber = generateRandomTicketNumber();
    const token = sessionStorage.getItem('accessToken');
    const decodedToken = await jwt_decode(token);
    const name = decodedToken.name;
    const azo = autok[index].azo;
    const selectedStartDate = new Date(dates.startDate);
    const selectedEndDate = new Date(dates.endDate);
    const berletidij = arak[0].ar * berlesAr
    const teljesar = berletidij + arak[0].kaucio
    //végigmegyünk a bérléseken és megvizsgáljuk hogy szerepel e az adatbázisunkban a felvenni kívánt adat
    const overlappingDates = berlesek.some((berles) => {
      //csak azokat a bérléseket vizsgáljuk amelyek a kiválasztott gépjárműre vonatkoznak
      if (berles.autoazo === azo) {
        const startDate = new Date(berles.kezdonap);
        const endDate = new Date(berles.zaronap);
        //kivételkezelés
        const databaseOverlap =
          (selectedStartDate >= startDate && selectedStartDate <= new Date(endDate.getTime() + 86400000)) ||
          (selectedEndDate >= startDate && selectedEndDate <= endDate) ||
          (startDate >= selectedStartDate && startDate <= selectedEndDate) ||
          (endDate >= selectedStartDate && endDate <= selectedEndDate);
        return databaseOverlap;
      }
    });
    if (dates.startDate > currentMonthDays || dates.startDate > nextMonthDays || dates.endDate > currentMonthDays || dates.endDate > nextMonthDays) {
      toast.warning('A bérlés zárónapja nem lehet korábbi a kezdőnapjánál!', { position: toast.POSITION.BOTTOM_RIGHT })
      return
    }
    else if (dates.startDate > dates.endDate) {
      toast.warning('A bérlés zárónapja nem lehet korábbi a kezdőnapjánál!', { position: toast.POSITION.BOTTOM_RIGHT })
      return
    }
    else if (overlappingDates) {
      toast.warning('A bérlés időtartama nem eshet egybe másik bérlés időtartamával!', { position: toast.POSITION.BOTTOM_RIGHT })
      setBerlesAr(null)
      return;
    }
    try {
      const post = await fetch("http://localhost:8898/foglalas", {
        method: "POST",
        headers: { "Content-type": "application/json" },
        body: JSON.stringify
          ({
            kezdo: dates.startDate, zaro: dates.endDate, autoAzo: azo, nev: name, rentId: ticketNumber, berletDij: berletidij, osszeg: teljesar
          })
      })
      if (post.status === 500) {
        toast.error('Szerver nem elérhető', { position: toast.POSITION.BOTTOM_RIGHT })
      } else if (post.status === 414) {
        toast.error('Nincs ilyen nevű felhasználó', { position: toast.POSITION.BOTTOM_RIGHT })
      }
      else {
        navigate('/')
        handleClick()
        toast.success(<div>Sikeres foglalás!<br />Azonosító: {ticketNumber}</div>, { position: toast.POSITION.BOTTOM_RIGHT })
        return
      }
    }
    catch (error) {
      console.error('Error:', error);
      return
    }

  }

  async function fetchKategoria() {
    try {
      const response3 = await fetch("http://localhost:8898/datum");
      const response2 = await fetch(`http://localhost:8898/ar?query=${prop}`);
      const response = await fetch(`http://localhost:8898/kategoria?query=${prop}`);
      const data2 = await response2.json();
      const data3 = await response3.json();
      const data = await response.json();
      setAutok(data);
      setArak(data2);
      setBerlesek(data3);
    } catch (error) {
      console.error('Error:', error);
    } finally {
      setLoading(false);
    }
  }

  useEffect(() => {
    fetchKategoria(prop);
  }, []);

  return (
    <div className='background bg-stylekinalat'>
      <Header />
      {loading ? (
        <Spinner />
      ) : (
        <div >
          <div className='pt-20 katcontainer justify-center items-center'>

            {
              autok.map((auto, i) => (
                <div key={i}>
                  <div className='katcontainer'>

                    <div className={`katcard w-96 bg-base-100 shadow-xl ${cardStates[i] ? 'flipped' : ''}`}>
                      <figure><img className='img' src={auto.url} alt="car" /></figure>

                      <div className="absolute back text-center pr-11">
                        <button className='idopontbutton text-sm sm:text-base md:text-lg lg:text-xl ml-8' onClick={() => {
                          if (open) {
                            setOpen(!open)

                          } else {
                            elerheto(i)
                            setOpen(!open)
                          }
                        }
                        }>Szabad időpontok</button>
                        <div className={`berleslista ${open && elerDates ? 'active' : 'inactive'}`}>{elerDates}</div>
                        <form className='katleiras' onSubmit={(event => submitClick(event, i))} onReset={() => handleVisszaClick(i)}>


                          <div className='grid grid-cols-2 gap-12 pl-10'>
                            <div className=''>
                              <p className='cardback'>Kezdőnap</p>
                              <input type="date" min={minStartDate} max={maxStartDateForm} name="startDate" value={dates.startDate} required onChange={(event) => handleDates(event, i)} />
                              <p className='cardback pt-2'>Kaució</p>
                              <div className='linediv'></div>
                              {
                                arak.map((egyAr, i) => (<p key={i} className='cardback'>{`${(egyAr.kaucio).toLocaleString('en-US', {
                                  maximumFractionDigits: 2
                                }).replace(',', '.')}` || '0'}.- Ft</p>))
                              }

                            </div>
                            <div>
                              <p className='cardback'>Zárónap</p>
                              <input type="date" min={minEndDate} max={maxEndDateForm} name="endDate" value={dates.endDate} disabled={!dates.startDate} required onChange={(event) => handleDates(event, i)} />
                              <p className='cardback pt-2'>Bérleti díj</p>
                              <div className='linediv'></div>
                              {
                                arak.map((egyAr, i) => (<p key={i} className='cardback'>{`${(egyAr.ar * berlesAr).toLocaleString('en-US', {
                                  maximumFractionDigits: 2
                                }).replace(',', '.')}` || ''}.- Ft</p>))
                              }

                            </div>
                          </div>
                          <button className='kinalatbuttonback' type='submit'>Foglalás</button>
                          <p></p>
                          <button onClick={() => handleVisszaClick(i)} className='kinalatbuttonback' type='reset'>Bezárás</button>



                        </form>

                        <p></p>


                      </div>

                      <h2 className=" card-title py-4 justify-center text-base sm:text-xl lg:text-2xl">{auto.marka} {auto.tipus}</h2>
                      <div className=" ml-2 mr-2 grid grid-cols-3">
                        <div className='katleiras text-sm sm:text-base md:text-lg lg:text-xl text-right '>
                          <p className='pb-3'>{auto.evjarat}</p>

                          <p className='pb-3'>{auto.ulesszam}</p>

                          <p >{auto.valto}</p>

                        </div>

                        <div className='relative grid grid-cols-2 '>
                          <div>
                            <img className='h-4 sm:h-6 md:h-7 absolute pl-2 top-[2px] md:top-[-1px]' src={calendar} />
                            <img className='h-5 sm:h-6 md:h-7 absolute pl-2 top-[34px] sm:top-9  md:top-[39px]' src={seat} />
                            <img className='h-5 sm:h-6 md:h-8 absolute pl-2 top-[65px] sm:top-[72px] md:top-20' src={gearbox} />
                          </div>
                          <div>
                            <img className='h-4 sm:h-6 md:h-7 absolute pl-9 top-[2px] sm:pl-7 md:pl-6 md:top-[-1px]' src={briefcase} />
                            <img className='h-4 sm:h-6 md:h-7 absolute pl-9 top-[34px] sm:pl-7 md:pl-6 sm:top-9 lg:top-[38px]' src={gaspump} />
                            <img className='h-4 sm:h-6 md:h-7 absolute pl-9 top-[67px] sm:pl-7 md:pl-5 sm:top-[72px] md:top-20' src={gps} />
                          </div>
                        </div>

                        <div className='leiras text-sm sm:text-base md:text-lg lg:text-xl text-left'>
                          <p className='pb-3'>{auto.csomagtarto} Liter</p>
                          <p className='pb-3'>{auto.uzemanyag}</p>
                          <p>{auto.gps}</p>
                        </div>
                      </div>
                      <div className="card-actions justify-center py-5">
                        <button onClick={() => logInClick(i)} className="kinalatbutton">FOGLALÁS</button>
                      </div>
                    </div>
                  </div>
                </div>))
            }
          </div>
        </div>
      )}</div>
  )
}

export default Autok