import React from 'react'
import '../styles/Styles.css'
import { useState, useEffect, useRef,useContext } from 'react'
import { Link } from 'react-router-dom';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import SpinnerContext from '../components/context/SpinnerContext';
import { useNavigate } from 'react-router-dom';
import CardContext from './context/CardContext';
function LoginButton(props) {


    return (
        <div>
            
            <div className="menu-container">
                <div className={`dropdown-menu w-[230px] top-[60px] sm:top-[80px] xl:top-[100px] sm:w-[230px] md:w-[250px] lg:w-[300px] xl:w-[320px] sm:w-[200px] ${props.open ? 'active' : 'inactive'}`}>
                    <ul><DropdownItem /></ul>
                </div>
            </div>
              </div>
    )
}

export function DropdownItem() {
    const navigate=useNavigate()
    const {handleClick}=useContext(CardContext)
    const { loading, setLoading } = useContext(SpinnerContext);
    const [isTransparent, setIsTransparent] = useState(true);
    const [email, setEmail] = useState("");
    const [pass, setPass] = useState("");
    const min_pass_length = 8;
    useEffect(() => {
        const handleScroll = () => {
            const top = window.pageYOffset || document.documentElement.scrollTop;
            if (top === 0) {
                setIsTransparent(true);
            } else {
                setIsTransparent(false);
            }
        };
        window.addEventListener('scroll', handleScroll);

        return () => {
            window.removeEventListener('scroll', handleScroll);
        };
    }, []);

    
    const onSubmit = async (e) => {
        e.preventDefault();
        if (pass.length < min_pass_length) {
            // Display an error message
            toast.warning(<div>A jelszó túl rövid<br />(legalább 8 karakter)</div>, { position: toast.POSITION.BOTTOM_RIGHT });
        } else try {
            const response = await fetch("http://localhost:8898/login", {
                method: "POST",
                headers: { "Content-type": "application/json" },
                body: JSON.stringify
                    ({
                        email: email, jelszo: pass
                    })
            })

            if (response.status === 410 || response.status === 408) {
                toast.error("Helytelen e-mail cím vagy jelszó", { position: toast.POSITION.BOTTOM_RIGHT });
            }
            else if (response.status === 404) {
                toast.warning("Kérjük adjon meg létező e-mailt", { position: toast.POSITION.BOTTOM_RIGHT });
            }
            else {
                //Sikeres bejelentkezés
                const data = await response.json();
                await sessionStorage.setItem('accessToken', data.accessToken);
                handleClick()
                navigate('/')
                setLoading(true)
                toast.success(<div>Bejelentkezés folyamatban...<br /> Az oldal újratölt!</div>, { position: toast.POSITION.BOTTOM_RIGHT })
                setTimeout(async() => {
                    
                    await window.location.reload();
                    setLoading(false)
                }, 5000);

            }
        } catch (error) {
            toast.error("A szerver jelenleg nem elérhető", { position: toast.POSITION.BOTTOM_RIGHT });
            console.log(error)
        }
    }
    return (
        
        <form onSubmit={onSubmit} className='dropdown  text-sm sm:text-sm md:text-base lg:text-lg xl:text-xl'>

            <label>E-mail</label>
            <input value={email} onChange={((e) => setEmail(e.target.value))} className='dropdowninput w-70 sm:w-70 md:w-[230] lg:w-[300] xl:w-[300]' type='email' required />
            <label>Jelszó</label>
            <input value={pass} onChange={((e) => setPass(e.target.value))} className='dropdowninput w-70 sm:w-70 md:w-[230] lg:w-[300] xl:w-[300]' type='password' required />
            <button className={`text-sm sm:text-sm md:text-base lg:text-lg xl:text-xl droplink ${isTransparent ? 'HLink' : 'HLink2'}`}>Bejelentkezés</button>
            <div>
                <Link to='/regisztracio' className={`text-sm sm:text-sm md:text-base lg:text-lg xl:text-xl ml-28 sm:ml-28 md:ml-32 lg:ml-40 xl:ml-44 droplink2 ${isTransparent ? 'HLink' : 'HLink2'}`}>Regisztráció</Link>
            </div>
            
        </form>
    )
}
<ToastContainer theme='dark' />
export default LoginButton