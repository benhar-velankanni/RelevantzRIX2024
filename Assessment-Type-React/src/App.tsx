import { BrowserRouter, Route, Routes } from 'react-router-dom'

import Navbar from './Components/Navbar'
import AuctionManagement from './Components/AuctionManagement'
import BidManagement from './Components/Bid'

function App() {
  //const [count, setCount] = useState(0)

  return (
    <BrowserRouter>
      <Navbar />
      <Routes>
        <Route path="/" element={<AuctionManagement />} />
        <Route path="/bid" element={<BidManagement />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App

