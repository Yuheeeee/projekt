import '../styles/Styles.css'
import Header from './Header'
import { useNavigate } from 'react-router-dom'
import { useState,useContext} from 'react';
import {ToastContainer, toast} from "react-toastify"
import 'react-toastify/dist/ReactToastify.css';
import CardContext from './context/CardContext'


function Register() {
  const {handleClick}=useContext(CardContext)
  const navigate = useNavigate();
  const [nev,setNev]=useState("");
  const [email,setEmail]=useState("");
  const [pass,setPass]=useState("");
  const [passIsmet,setPassIsmet]=useState("");
  const [telepules,setTelepules]=useState("");
  const [irszam,setIrszam]=useState("");
  const [cim,setCim]=useState("");
  const [telszam,setTelszam]=useState("");

  const min_pass_length=8;

  const onSubmit= async (e)=>{
    e.preventDefault();
    if (pass.length < min_pass_length) {
      // Display an error message
      toast.warning(<div>A jelszó túl rövid<br/>(legalább 8 karakter)</div>,{position:toast.POSITION.BOTTOM_RIGHT});
    } else if (pass!==passIsmet){
      toast.warning("A jelaszavak nem egyeznek",{position:toast.POSITION.BOTTOM_RIGHT})
    } 
    else
    try{
       const response = await fetch("http://localhost:8898/user/register",{
        method:"POST",
        headers:{"Content-type":"application/json"},
        body:JSON.stringify
        ({
        nev:nev,irsz:irszam,telep:telepules,cim:cim,email:email,tel:telszam,jelszo:pass
        })
        
      })
      
      
      if (response.status===410) {
        toast.error("Foglalt e-mail cím",{position:toast.POSITION.BOTTOM_RIGHT});
        
      } 
      else if(response.status===404) {
        toast.warning("Kérjük adjon meg létező e-mailt",{position:toast.POSITION.BOTTOM_RIGHT});
      }
      else if (response.status===401) {
        toast.error("Foglalt név",{position:toast.POSITION.BOTTOM_RIGHT});
      }
      else {
        //Sikeres regisztráció
        toast.success('Sikeres regisztráció',{position:toast.POSITION.BOTTOM_RIGHT})
        navigate('/'); 
        handleClick();
      }  
    } catch (error) {
      toast.error("A szerver jelenleg nem elérhető",{position:toast.POSITION.BOTTOM_RIGHT});
      console.log(error)
      
    }
    
    
}


  return (
    <>
      <Header />
      <div className='register'>
        <form onSubmit={onSubmit}  className='registerform'>
          <label>E-mail</label>
          <input value={email} onChange={((e) => setEmail(e.target.value))} className='forminput' type='email' required />
          <label>Jelszó</label>
          <input value={pass} onChange={((e) => setPass(e.target.value))} className='forminput' type='password' required />
          <label>Jelszó ismét</label>
          <input value={passIsmet} onChange={((e) => setPassIsmet(e.target.value))} className='forminput' type='password' required />
          <label>Teljes név</label>
          <input value={nev} onChange={((e) => setNev(e.target.value))} className='forminput' type='text' required />
          <label>Település</label>
          <input value={telepules} onChange={((e) => setTelepules(e.target.value))} className='forminput' type='text' />
          <label>Irányítószám</label>
          <input value={irszam} onChange={((e) => setIrszam(e.target.value))} className='forminput' type="number" />
          <label>Lakcím</label>
          <input value={cim} onChange={((e) => setCim(e.target.value))} className='forminput' type='text' />
          <label>Telefonszám</label>
          <input value={telszam} onChange={((e) => setTelszam(e.target.value))} className='forminput' type='number' placeholder='06...' />
          <button className='button'> REGISZTRÁCIÓ</button>
          


        </form>
        <ToastContainer theme='dark'/>

      </div>
    </>
  )
}

export default Register