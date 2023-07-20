import React from 'react';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import { Icon } from 'leaflet';
//for appropriate displaying of the map
import 'leaflet/dist/leaflet.css'
import markerIcon from '../kepek/marker.png';
import '../styles/Styles.css'
import Header from './Header';

const LeafletMap = () => {


  const position = [46.70376006418411, 21.064146481509013]; // Example initial position
  const customMarkerIcon = new Icon({
    iconUrl: markerIcon,
    iconSize: [25, 41],
    iconAnchor: [12, 41],
    popupAnchor: [0, -41],
  })
  const mapContainerStyle = {

    borderRadius: '10px', // Rounded border
    overflow: 'hidden', // Hide overflow to prevent marker overflow
    height: '300px',

  };

  return (
    <MapContainer center={position} zoom={13} style={mapContainerStyle}>
      <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
      />
      <Marker position={position}>
        <Popup>
          <a href="https://www.google.com/maps/place/B%C3%A9k%C3%A9scsaba,+Ber%C3%A9nyi+%C3%BAt+150,+5600/@46.7036203,21.0616145,17z/data=!3m1!4b1!4m5!3m4!1s0x4744297ee7b7fc2b:0x1c13a579a35d5f43!8m2!3d46.7036203!4d21.0641894">MUKEBU Gépjárműpark</a>
        </Popup>
      </Marker>

    </MapContainer>
  );
};
function Kapcsolat() {

  return (
    <div className='background h-full bg-stylekinalat overflow-hidden'>
      <Header />
      <div className='py-[10%] flex-container'>
        <div className='cardKapcsolat pt-10 text-sm sm:text-base md:text-lg xl:text-xl'>

          <p className='parag'>
            <i className=' fa-solid fa-map-location-dot fa-xl'></i>
            <i> 5600 Békéscsaba, Berényi út 150.</i></p>
          <p className='parag'>
            <i className=" fa-solid fa-envelope pt-10 fa-xl" ></i>
            <i className=' xl:text-xl'> mukebu@mukebu.hu</i>
          </p>
          <p className='parag'>
            <i className=' fa-solid fa-phone pt-10 fa-xl'></i>
            <i className=' xl:text-xl'> 06/89-520-8898</i>
          </p>
        </div>
        <div className='cardKapcsolat'>
          <LeafletMap />
        </div>

      </div>
    </div>
  );
}

export default Kapcsolat