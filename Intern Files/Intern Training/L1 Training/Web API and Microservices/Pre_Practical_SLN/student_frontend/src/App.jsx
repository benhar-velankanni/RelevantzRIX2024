//App.jsx

import {
    Routes,
    Route,
    Link
} from 'react-router-dom';

import StudentPage from './pages/StudentPage';


function App() {
    return (
        <div className="container">
            <table style={{ width: '100%', borderCollapse: 'collapse' }}>
                <tbody>
                    <tr>
                        <td colSpan="3">
                            <nav style={{ marginBottom: '1rem' }}>
                                <Link to="/"><button>Home</button></Link>
                                &nbsp;
                                <Link to="/student"><button>Student Page</button></Link>
                            </nav>
                        </td>
                    </tr>
                    <tr>
                        <td colSpan="3">
                            <Routes>
                                <Route path="/" element={null} />
                                <Route path="/student" element={<StudentPage />} />
                            </Routes>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

    );
}

export default App;