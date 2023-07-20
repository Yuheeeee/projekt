import React from 'react'
import { useState, useEffect } from 'react';
import img1 from '../kepek/img1.jpg'
import img2 from '../kepek/img2.jpg'
import img3 from '../kepek/img3.jpg'
import img4 from '../kepek/img4.jpg'
import '../styles/Styles.css'
import 'react-toastify/dist/ReactToastify.css';

function FooldalContent() {
  const [scrollY, setScrollY] = useState(0);
  const [scrollY2, setScrollY2] = useState(0)
  const [scrollY3, setScrollY3] = useState(0)
  const [scrollY4, setScrollY4] = useState(0)
  useEffect(() => {
    window.addEventListener("scroll", handleScroll);
    return () => {
      window.removeEventListener("scroll", handleScroll);
    };
  }, []);

  let multiplier2 = 0.6;
  let multiplier4 = 2 //parallax2
  let multiplier3 = 0.5;//parallax 3
  let multiplier = 1;

  if (innerWidth >= 1050) {
    multiplier = 0.75
    multiplier4 = 0.79
    multiplier3 = 1.2
  } else if (innerWidth > 536 && innerWidth < 784) {
    multiplier3 = 0.88
    multiplier = 0.88
    multiplier4 = 0.85
  } else if (innerWidth >= 784 && innerWidth < 1050) {
    multiplier3 = 0.92
    multiplier = 0.95
    multiplier4 = 1.05
  } else if (innerWidth <= 536) {
    multiplier3 = 1.18
    multiplier = 1.15
    multiplier4 = 1.1
  }

  //Responsive scroll effect start
  const handleScroll = () => {
    setScrollY(window.pageYOffset);
    const scrollPosition = window.pageYOffset;
    if (innerWidth >= 1050) {
      setScrollY3(window.pageYOffset * 1.2);
      setScrollY4(window.pageYOffset * 0.8);
    }
    else if (innerWidth <= 784 && innerWidth >= 536) {
      setScrollY3(window.pageYOffset * 1.3);
      setScrollY4(window.pageYOffset * 1.2);
    }
    else if (innerWidth > 784 && innerWidth <= 1050) {
      setScrollY3(window.pageYOffset * 1);
      setScrollY4(window.pageYOffset * 1.1);
    }
    else if (innerWidth < 536) {
      setScrollY3(window.pageYOffset * 1)
      setScrollY4(window.pageYOffset * 0.9);
    }

    if (innerWidth >= 1150) {
      if (scrollPosition <= 650) {
        setScrollY2(scrollPosition * 1.05);
      }
    }
    else if (innerWidth >= 850 && innerWidth < 1150) {
      if (scrollPosition <= 540) {
        setScrollY2(scrollPosition * 1.2);
      }
    }
    else if (innerWidth < 850) {

      if (scrollPosition <= 400) {
        setScrollY2(scrollPosition * 1.7);
      }
    }

  };
  //Responsive scroll effect end

  //Image timer
  const [activeSlide, setActiveSlide] = useState(1);
  useEffect(() => {
    const intervalId = setInterval(() => {
      setActiveSlide((activeSlide) => {
        if (activeSlide < 4) {
          return activeSlide + 1;

        } else {
          return 1;
        }
      });
    }, 5000);

    return () => {
      clearInterval(intervalId);
    };
  }, []);

  return (
    <div className='bg-black overflow-hidden ' >
      <div className="relative padding">
        <div id="slide1" className={`bg-style ${activeSlide === 1 ? "shown" : "hidden"}`} style={{ backgroundImage: `url(${img1})`, transform: `translateY(${scrollY * 0.5}px) ` }}></div>
        <div id="slide2" className={`bg-style ${activeSlide === 2 ? "shown" : "hidden"}`} style={{ backgroundImage: `url(${img2})`, transform: `translateY(${scrollY * 0.5}px) ` }}></div>
        <div id="slide3" className={`bg-style ${activeSlide === 3 ? "shown" : "hidden"}`} style={{ backgroundImage: `url(${img3})`, transform: `translateY(${scrollY * 0.5}px) ` }}></div>
        <div id="slide4" className={`bg-style ${activeSlide === 4 ? "shown" : "hidden"}`} style={{ backgroundImage: `url(${img4})`, transform: `translateY(${scrollY * 0.5}px) ` }}></div>
        <div className='blur h-[540px] sm:h-[570px] md:h-[590px]' style={{ transform: `translateY(${scrollY * 0.3}px)` }} />
      </div>

      <div className='relative z-10 background bg-style roundedborder ' style={{ transform: `translateY(${scrollY * -0.1}px)` }}>
        <p className='pt-48 sm:pt-28 text-2xl sm:text-3xl md:text-4xl paragraf1'>MUKEBU Autóbérlés</p>
        <div className='grid grid-cols-2 gap-10 px-10 place-content-center py-32 col-start-1'>
          <div className='text-justify h-[500px]' style={{ transform: `translateX(${-410 + scrollY2 * multiplier2}px)` }}>
            <p className='pb-4 text-sm sm:text-lg sm:py-6 md:py-10 lg:py-16 paragraf2 '>TALÁLKOZZUNK A MUKEBU GÉPJÁRMűPARKBAN!</p>
            <p className='py-4 text-xs sm:text-base sm:py-6 md:py-6 lg:py-16  paragraf3'>Engedd meg, hogy levegyük a válladról a gépjárműtartással járó nehézségeket és megkönnyítsük számodra az utazást!</p>
            <p className='paragraf3 text-xs sm:text-base'>Megmutatjuk neked hogyan teheted meg mindezt nálunk online, a saját ízlésedre szabva! Széles kínálatunknak köszönhetően biztosíthatunk arról, hogy minden igényednek maximálisan meg tudunk felelni.</p>
          </div>
          <div className='background1 h-[350px] sm:h-[400px] lg:h-[500px] bg-center' style={{ transform: `translateX(${410 + scrollY2 * -multiplier2}px)` }}>
          </div>
        </div>
        <p className='paragraf1 text-2xl sm:text-3xl md:text-4xl'>1. REGISZTRÁCIÓ</p>
        <div className='grid grid-cols-2 gap-10 px-10 place-content-center py-44 col-start-1 absolute'>
          <div className='registerimage bg-center h-[300px] sm:h-[400px]' style={{ transform: `translateY(${1000 + scrollY3 * -multiplier}px)` }}>
          </div>
          <div className='text-justify h-[500px]' style={{ transform: `translateY(${1000 + scrollY3 * -multiplier}px)` }}>
            <p className='text-xs sm:text-base sm:pt-4  md:pt-12  xl:pt-16 paragraf3 '>Kattints a bejelentkezés gombra, majd a felugró ablakban válaszd ki a regisztráció lehetőséget!</p>
            <p className='text-xs sm:text-base py-4  sm:py-10 md:py-12  lg:py-16 paragraf3'>Töltsd ki a szükséges mezőket, ezt követően a weboldal vissza fog irányítani a főoldalra amennyiben minden adat kitöltésre került megfelelő formában.</p>
            <p className='text-xs sm:text-base paragraf3'>Végül kattints a "Bejelentkezés" menüpontra és add meg a felhasználói adataid!</p>
          </div>
        </div>
        <p className='paragraf1 text-2xl sm:text-3xl md:text-4xl padding2'>2. ONLINE BÉRLÉS</p>
        <div className='grid grid-cols-2 gap-10 px-10 place-content-center col-start-1 absolute'>
          <div className='rentimage h-[300px] sm:h-[400px] bg-center' style={{ transform: `translateY(${2000 + scrollY3 * -multiplier4}px)` }}>
          </div>
          <div className='text-justify h-[500px]' style={{ transform: `translateY(${2000 + scrollY3 * -multiplier4}px)` }}>
            <p className='text-xs sm:text-sm sm:pt-4  md:pt-12  xl:pt-16 paragraf3 '>Válaszd ki az autók menüpontot a kategóriák megjelenításáhez. A számodra megfelelelő kategória kiválasztását követően látható az adott kategóriához tartozó kínálatunk.</p>
            <p className='text-xs sm:text-sm py-4  sm:py-10 md:py-12  lg:py-16 paragraf3'>Bejelentkezés után a foglalás gombra kattintva a kártya hátoldalán válaszd ki a bérlés kezdő és zárónapját. Elérhető dátumaink szintén listázva vannak minden autó esetében a könnyebb foglalás érdekében.</p>
            <p className='text-xs sm:text-sm paragraf3'>Amennyiben foglalásod sikeres volt egy bérlésazonosítót generál számodra a rendszer, mely alapján a bérlés napján a gépjárművet rendekezdésedre bocsájtjuk!</p>
          </div>
        </div>
        <p className='paragraf1 text-2xl sm:text-3xl md:text-4xl padding2'>ÚTRA FEL!</p>
        <div className='grid grid-cols-2 gap-10 px-10 place-content-center py-44 col-start-1'>
          <div className='carkeyimg h-[300px] sm:h-[400px]  bg-center' style={{ transform: `translateY(${2500 + scrollY4 * -multiplier3}px)` }}>
          </div>
          <div className='text-justify h-[500px]' style={{ transform: `translateY(${2500 + scrollY4 * -multiplier3}px)` }}>
            <p className='pt-16 pb-4 text-xs sm:text-base pt-8 sm:pt-20 md:pt-24 xl:pt-32 paragraf3 '>Találkozzunk gépjárműparkunkban a foglalás napján és pár perces ügyintézést követően már készen is állsz bérelt gépjárműveddel az utazásra!</p>
            <p className='py-2 sm:py-10 text-xs sm:text-base sm:pt-4 md:py-12  lg:py-16 paragraf3'>Kellemes utat kíván minden leendő és meglévő bérlőjének a MUKEBU csapata!</p>
          </div>

          <div className='absolute w-full flex-container2 pt-[770px]'>
            <div className='infostyle text-left text-xs sm:text-xs md:text-sm lg:text-base lg:pl-11'>
              <i className=' fa-solid fa-map-location-dot fa-xl'></i>
              <i className=' xl:text-xl'> 5600 Békéscsaba, Berényi út 150.</i>
              <br />
              <i className=" fa-solid fa-envelope pt-10 fa-xl" ></i>
              <i className=' xl:text-xl'> mukebu@mukebu.hu</i>
              <br />
              <i className=' fa-solid fa-phone pt-10 fa-xl'></i>
              <i className=' xl:text-xl'> 06/89-520-8898</i>
            </div>
            <div className='infostyle text-center'>
              <i className="pointer fa-brands fa-facebook fa-2xl "></i>
              <br />
              <i className="pointer fa-brands fa-instagram fa-2xl pt-10"></i>
              <br />
              <i className="pointer fa-brands fa-tiktok pt-10 fa-2xl"></i>
            </div>
            <div className='infostyle text-right infostyle pr-6 sm:pr-2 text-left text-xs sm:text-xs md:text-sm lg:text-base  lg:pr-11'>
              <i className="pointer fa-solid fa-cookie fa-xl"></i>
              <i className='pointer xl:text-xl'> Cookies</i>
              <br />
              <i className="pointer fa-solid fa-file-shield pt-10 fa-xl"></i>
              <i className='pointer xl:text-xl'> ÁSZF</i>
              <br />
              <i className="pointer fa-solid fa-circle-question pt-10 fa-xl"></i>
              <i className='pointer xl:text-xl'> GY.I.K.</i>
            </div>
          </div>
        </div>
        <div>
        </div>
      </div>
    </div>
  )
}

export default FooldalContent