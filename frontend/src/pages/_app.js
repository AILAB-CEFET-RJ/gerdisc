import '@/styles/globals.css'

export default function App({ Component, pageProps }) {
  pageProps.name = "Emmanuel"
  pageProps.role = "Administrator"
  return <Component {...pageProps} />
}
