//App.jsx

import {
    Routes,
    Route,
    Link
} from 'react-router-dom';

import GlossaryPage from './pages/GlossaryPage';
import LanguagePage from './pages/LanguagePage';
import TranslationPage from './pages/TranslationPage';
import HomePage from './pages/HomePage';


function App() {
    return (
        <div className="container" style={{ marginTop: '30px' }}>
            <table style={{ width: '100vh', borderCollapse: 'collapse' }}>
                <tbody>
                    <tr>
                        <td colSpan="4">
                            <nav style={{ marginBottom: '1rem', width: '100%' }}>
                                <Link to="/"><button>Home</button></Link>
                                &nbsp; &nbsp;
                                <Link to="/glossaryManager"><button>Glossary</button></Link>
                                &nbsp; &nbsp;
                                <Link to="/languageManager"><button>Language</button></Link>
                                &nbsp; &nbsp;
                                <Link to="/translationManager"><button>Translation</button></Link>
                            </nav>
                        </td>
                    </tr>
                    <tr>
                        <td colSpan="3">
                            <Routes>
                                <Route path="/" element={<HomePage />} />
                                <Route path="/glossaryManager" element={<GlossaryPage />} />
                                <Route path="/languageManager" element={<LanguagePage />} />
                                <Route path="/translationManager" element={<TranslationPage />} />
                            </Routes>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

    );
}

export default App;
