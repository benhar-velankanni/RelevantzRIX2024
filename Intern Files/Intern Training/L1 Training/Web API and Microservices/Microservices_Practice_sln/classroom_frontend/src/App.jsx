//App.jsx

import {
    Routes,
    Route,
    Link
} from 'react-router-dom';

import StudentPage from './pages/StudentPage';
import TeacherPage from './pages/TreacherPage';


function App() {
    return (
        <div className="container" style={{ marginTop: "20px" }}>
            <table style={{ width: '100%', borderCollapse: 'collapse' }}>
                <tbody>
                    <tr>
                        <td colSpan="3">
                            <nav style={{ marginBottom: '1rem' }}>
                                <Link to="/"><button>Home</button></Link>
                                &nbsp;
                                <Link to="/student"><button>Student Page</button></Link>
                                &nbsp;
                                <Link to="/teacher"><button>Teacher Page</button></Link>
                            </nav>
                        </td>
                    </tr>
                    <tr>
                        <td colSpan="3">
                            <Routes>
                                <Route path="/" element={null} />
                                <Route path="/student" element={<StudentPage />} />
                                <Route path="/teacher" element={<TeacherPage />} />
                            </Routes>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

    );
}

export default App;