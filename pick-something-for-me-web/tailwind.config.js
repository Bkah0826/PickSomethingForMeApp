/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js}"],
  darkMode: false,
  theme: {
    extend: {
      colors: {
        Fuschia100: '#EF5DA8',
        Fuschia80: '#F178B6',
        Fuschia60: '#FCDDEC',
        Iris100: '#5D5FEF',
        Iris80: '#7879F1',
        Iris60: '#A5A6F6',
      },
      fontFamily: {
        DroidSans: ['Droid Sans', 'sans']
      }
    },
  },
  variants: {
    extend:{},
  },
  plugins: [],
}

