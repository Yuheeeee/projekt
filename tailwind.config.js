/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
],
  theme: {
    extend: {
      colors:{
        HText:'#D5BF75',
        bordercolor:'#D5BF75',
          
      
      }
    },
  },
  plugins: [require("daisyui")],
}

