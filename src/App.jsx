
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom'
import Fooldal from './components/Fooldal'
import SzAuto from './components/SzAuto'
import Kapcsolat from './components/Kapcsolat'
import HAuto from './components/HAuto'
import CsAuto from './components/CsAuto'
import LAuto from './components/LAuto'
import Register from './components/Register'
import Kinalat from './components/Kinalat'
import { ToastContainer } from 'react-toastify'
import { CardProvider } from './components/context/CardContext'
import { SpinnerProvider } from './components/context/SpinnerContext'

function App() {

  return (

    <Router>
      <CardProvider>
        <SpinnerProvider>
      <ToastContainer theme="dark"/>
      <Routes>
        <Route path='/' element={<Fooldal />} />
        <Route path='*' element={<Navigate to={'/'} />} />
        <Route path='/szemelyautok' element={<SzAuto />} />
        <Route path="/csaladiautok" element={<CsAuto/>}/>
        <Route path="/kisbuszok" element={<HAuto/>}/>
        <Route path='/luxusautok' element={<LAuto/>}/>
        <Route path='/kapcsolat' element={<Kapcsolat />} />
        <Route path='/regisztracio' element={<Register/>}/>
        <Route path='/kategoriak' element={<Kinalat/>}/>
      </Routes>
      </SpinnerProvider>
      </CardProvider>
    </Router>

  )
}

export default App
