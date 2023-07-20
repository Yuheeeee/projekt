import React from 'react'
import Header from './Header'
import aKat from '../kepek/aKat.jpg'
import bKat from '../kepek/bKat.jpg'
import cKat from '../kepek/cKat.jpg'
import dKat from "../kepek/dKat.jpg"
import '../styles/Styles.css'
import {Link} from 'react-router-dom'

function Kinalat() {
    return (
        <div className='absolute background bg-stylekinalat'>
            <Header />
            <div className='py-[10%] flex-container'>
                <div className="card bg-base-100 shadow-xl">
                    <figure><img src={aKat} alt="szemelyauto" /></figure>
                    <h2 className="card-title py-4 justify-center text-base sm:text-xl lg:text-2xl">A KATEGÓRIA</h2>
                    <div className="gap-8 text-xs sm:text-base md:text-lg lg:text-xl ml-2 mr-2 grid grid-cols-2">
                        <div className='leiras text-right'>
                            <p className='pb-3'>ALACSONY FOGYASZÁS</p>
                            <p>ALSÓ ÁRKATEGÓRIA</p>
                        </div>
                        <div className='leiras text-left'>
                            <p className='pb-3'>VÁROSI HASZNÁLATRA</p>
                            <p>ALAP FELSZERELTSÉG</p>
                        </div>
                    </div>
                    <div className="card-actions justify-center py-5">
                    <Link to='/szemelyautok'><button className="kinalatbutton">KÍNÁLAT</button></Link>
                    </div>
                </div>
                <div className="card bg-base-100 shadow-xl">
                    <figure><img src={bKat} alt="csaladiauto" /></figure>
                    <h2 className="card-title py-4 justify-center text-base sm:text-xl lg:text-2xl">B KATEGÓRIA</h2>
                    <div className="gap-8 text-xs sm:text-base md:text-lg lg:text-xl  ml-2 mr-2 grid grid-cols-2">
                        <div className='leiras text-right'>
                            <p className='pb-3'>NAGY CSOMAGTÉR</p>
                            <p>KÖZÉP ÁRKATEGÓRIA</p>
                        </div>
                        <div className='leiras text-left'>
                            <p className='pb-3'>CSALÁDOK SZÁMÁRA</p>
                            <p>KÖZÉP FELSZERELTSÉG</p>
                        </div>
                    </div>
                    <div className="card-actions justify-center py-5">
                    <Link to='/csaladiautok'><button className="kinalatbutton">KÍNÁLAT</button></Link>
                    </div>
                </div>
                <div className="card bg-base-100 shadow-xl">
                    <figure><img src={cKat} alt="kisbusz" /></figure>
                    <h2 className="card-title text-sm sm:text-base md:text-lg lg:text-xl py-4 justify-center text-base sm:text-xl lg:text-2xl">C KATEGÓRIA</h2>
                    <div className="gap-8 text-xs sm:text-base md:text-lg lg:text-xl ml-2 mr-2 grid grid-cols-2">
                        <div className='leiras text-right'>
                            <p className='pb-3'>7+ SZEMÉLYES UTASTÉR</p>
                            <p>KÖZÉP ÁRKATEGÓRIA</p>
                        </div>
                        <div className='leiras text-left'>
                            <p className='pb-3'>CSOPORTOS SZÁLLÍTÁSRA</p>
                            <p>KÖZÉP FELSZERELTSÉG</p>
                        </div>
                    </div>
                    <div className="card-actions justify-center py-5">
                    <Link to='/kisbuszok'><button className="kinalatbutton">KÍNÁLAT</button></Link>
                    </div>
                </div>
                <div className="card bg-base-100 shadow-xl">
                    <figure><img src={dKat} alt="luxusauto" /></figure>
                    <h2 className="card-title py-4 justify-center text-base sm:text-xl lg:text-2xl">D KATEGÓRIA</h2>
                    <div className="mr-2 text-xs sm:text-base md:text-lg lg:text-xl ml-2 gap-8 grid grid-cols-2">
                        <div className='leiras text-right'>
                            <p className='pb-3'>NAGY TELJESÍTMÉNY</p>
                            <p>FELSŐ ÁRKATEGÓRIA</p>
                        </div>
                        <div className='leiras text-left'>
                            <p className='pb-3'>PRÉMIUM MEGJELENÉS</p>
                            <p>PRÉMIUM FELSZERELTSÉG</p>
                        </div>
                    </div>
                    <div className="card-actions justify-center py-5">
                        <Link to='/luxusautok'><button className="kinalatbutton">KÍNÁLAT</button></Link>
                    </div>
                    
                </div>



            </div>
        </div>
    )
}

export default Kinalat