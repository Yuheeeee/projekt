import React from 'react';
import { useState,useEffect } from 'react';
import { PropagateLoader } from 'react-spinners';

function Spinner () {
        return (
        <div
            style={{
              display: 'flex',
              justifyContent: 'center',
              alignItems: 'center',
              height: '100vh',
              
            }}
          >
            <PropagateLoader color="#D5BF75" size={30}/>
          </div>
          )
    
  
};

export default Spinner;