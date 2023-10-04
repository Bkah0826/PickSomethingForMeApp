/** @type {import('tailwindcss').Config} */
const defaultTheme = require('tailwindcss/defaultTheme')
module.exports = {
  content: ["./src/**/*.{html,js}"],
  darkMode: false,
  theme: {
    extend: {
      colors: {
        offwhite: '#f0f0f0',
      },
      fontFamily: {
        default: ['Sen', 'sans-serif']
      }
    },
  },
  variants: {
    extend:{},
  },
  plugins: [],
}

