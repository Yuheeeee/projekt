import React, { createContext, useState } from 'react';

const SpinnerContext = createContext();

export function SpinnerProvider({ children }) {
  const [loading, setLoading] = useState(false);

  return (
    <SpinnerContext.Provider value={{ loading, setLoading }}>
      {children}
    </SpinnerContext.Provider>
  );
}

export default SpinnerContext;