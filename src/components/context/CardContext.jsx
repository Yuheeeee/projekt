import {createContext} from 'react';

const CardContext=createContext();

export const CardProvider=({children})=>{

    
    //Dátumok összehasonlításához formázás metódus
    const formatDate=(date)=> {
        const year = date.getFullYear();
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const day = String(date.getDate()).padStart(2, '0');
        return `${year}-${month}-${day}`;
      }

      const handleClick = () => {
        window.scrollTo({ top: 0, behavior: 'smooth' });
      };

      const generateRandomTicketNumber=()=> {
        const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
        const ticketLength = 8;
        let ticketNumber = '';
    
        for (let i = 0; i < ticketLength; i++) {
          const randomIndex = Math.floor(Math.random() * characters.length);
          const randomCharacter = characters.charAt(randomIndex);
          ticketNumber += randomCharacter;
        }
        return ticketNumber;
      }

    return <CardContext.Provider value={{formatDate,handleClick,generateRandomTicketNumber}}>{children}</CardContext.Provider>
}

export default CardContext;