import React from 'react'
import logo1 from '../kepek/logo.png'
import logo2 from '../kepek/logo2.png'
import { useState, useEffect, useRef, useContext } from 'react';
import "../styles/Styles.css"
import { Link } from 'react-router-dom';
import LoginButton from './LoginButton';
import '../styles/Styles.css'
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import CardContext from './context/CardContext'
import SpinnerContext from '../components/context/SpinnerContext';
import Spinner from './Spinner';
import { useNavigate } from 'react-router-dom';


function Header() {
    const navigate=useNavigate()
    const { loading, setLoading } = useContext(SpinnerContext);
    const { handleClick } = useContext(CardContext);
    const [loggedIn, setLoggedIn] = useState(false);
    const [isTransparent, setIsTransparent] = useState(true);
    const [open, setOpen] = useState(false);
    let Ref = useRef();
    const [windowWidth, setWindowWidth] = useState(window.innerWidth);

    useEffect(() => {
        // Update windowWidth state on window resize
        const handleResize = () => {
            setWindowWidth(window.innerWidth);
        };

        window.addEventListener('resize', handleResize);

        return () => {
            window.removeEventListener('resize', handleResize);
        };
    }, []);

    const isSmallScreen = windowWidth < 768; // Set the screen size breakpoint

    useEffect(() => {
        const token = sessionStorage.getItem("accessToken");
        if (token) {
            setLoggedIn(true);
        }
    }, []);
    useEffect(() => {
        let handler = event => {
            if (Ref.current && !Ref.current.contains(event.target)) {
                setOpen(false)

            }
        }
        document.addEventListener("mousedown", handler)
        return () => {
            document.addEventListener("mousedown", handler)
        }
    }, []);

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


    return (

        <div className={`bg-black roundedheader fixed w-full sm:h-12 md:h-14 lg:h-16 xl:h-20 h-12 indexcss ${isTransparent ? 'bg-opacity-0' : 'bg-opacity-100'} `} >
            {loading ? (
                <Spinner />
            ) : (

            <><Link to='/'><img src={isTransparent ? logo2 : logo1} onClick={handleClick} className='h-8 sm:h-8 md:h-10 lg:h-12 xl:h-16  h-8 my-2 mx-6 justify-center object-center absolute' /></Link><div className={`flex justify-center items-center w-full
            sm: h-12 md:h-14 lg:h-16 xl:h-20 
            mx-[99px] sm: mx-[120px] md:mx-32 lg:mx-44 xl:mx-60    
            space-x-8 sm:space-x-20 md:space-x-10 lg:space-x-28 xl:space-x-40 `}>
                        {isSmallScreen ? (
                            <>

                                <Link to={'/'}><div className={`${isTransparent ? 'text-white' : 'text-HText'} ${isTransparent ? 'HLink' : 'HLink2'}`} onClick={handleClick} style={isTransparent ? { color: 'white' } : { color: '#D5BF75' }}><i className='pointer fa-solid fa-house '></i></div></Link>
                                <Link to={'/kategoriak'}><div className={`${isTransparent ? 'text-white' : 'text-HText'} ${isTransparent ? 'HLink' : 'HLink2'}`} onClick={handleClick} style={isTransparent ? { color: 'white' } : { color: '#D5BF75' }}><i className='pointer fa-solid fa-car '></i></div></Link>
                                <Link to={'/kapcsolat'}><div className={`${isTransparent ? 'text-white' : 'text-HText'} ${isTransparent ? 'HLink' : 'HLink2'}`} onClick={handleClick} style={isTransparent ? { color: 'white' } : { color: '#D5BF75' }}><i className='pointer fa-solid fa-phone '></i></div></Link>
                                <div className={`pointer ${isTransparent ? 'text-white' : 'text-HText'} ${isTransparent ? 'HLink' : 'HLink2'}`}
                                    onClick={async() => {
                                        if (loggedIn) {
                                            await sessionStorage.removeItem("accessToken");
                                            navigate('/')
                                            setLoggedIn(false);
                                            setLoading(true);
                                            handleClick();
                                            toast.success(<div>Kijelentkezés folyamatban...<br />Az oldal újratölt!</div>, { position: toast.POSITION.BOTTOM_RIGHT });
                                            setTimeout(() => {
                                                setLoading(false);
                                                window.location.reload();
                                            }, 5000);
                                        } else {
                                            setOpen(!open);
                                        }
                                    } }>{loggedIn ? (<>
                                        <i className="fa-solid fa-circle-xmark"></i>

                                    </>
                                    ) : (
                                        <>
                                            <span className='fa-solid fa-right-to-bracket fa-lg'></span>
                                        </>)}</div>
                            </>
                        ) : (
                            <>
                                <Link to={'/'} onClick={handleClick} className={`${isTransparent ? 'text-white' : 'text-HText'} ${isTransparent ? 'HLink' : 'HLink2'}`}>Főoldal</Link>
                                <Link to={'/kategoriak'} onClick={handleClick} className={`${isTransparent ? 'text-white' : 'text-HText'} ${isTransparent ? 'HLink' : 'HLink2'}`}>Autók</Link>
                                <Link to={'/kapcsolat'} onClick={handleClick} className={`${isTransparent ? 'text-white' : 'text-HText'} ${isTransparent ? 'HLink' : 'HLink2'}`}>Kapcsolat</Link>
                                <p className={`pointer ${isTransparent ? 'text-white' : 'text-HText'} ${isTransparent ? 'HLink' : 'HLink2'}`}
                                    onClick={() => {
                                        if (loggedIn) {
                                            sessionStorage.removeItem("accessToken");
                                            navigate('/')
                                            setLoggedIn(false);
                                            handleClick();
                                            setLoading(true)
                                            toast.success(<div>Kijelentkezés folyamatban...<br />Az oldal újratölt!</div>, { position: toast.POSITION.BOTTOM_RIGHT });
                                            setTimeout(() => {
                                                setLoading(false)
                                                window.location.reload();
                                            }, 5000);
                                        } else {
                                            setOpen(!open);
                                        }
                                    } }>{loggedIn ? "Kijelentkezés" : "Bejelentkezés"}</p>
                            </>
                        )}


                        <div className={`${isTransparent ? 'text-white' : 'text-HText'} ${isTransparent ? 'HLink' : 'HLink2'}`} ref={Ref}><LoginButton open={open} /></div>
                    </div></>
            )}
        </div>

    )
}

export default Header