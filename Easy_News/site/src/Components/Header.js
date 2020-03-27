import React from 'react';

// CSS
import '../Assets/scss/Header.scss';
import {Link} from "react-router-dom";

function Header() {
    return (
        <header>

            <div className="container">
                <div className="Logo">
                    <Link to="/">Easy News</Link>
                </div>

                <nav>
                    <ul>
                        <li>
                            <Link to="/">Accueil</Link>
                        </li>
                        <li>
                            <Link to="/list">Dernières actualités</Link>
                        </li>
                        <li>
                            <div>Rechercher une actualité :</div>
                        </li>
                        <li>
                        <input type="text" className="form-control" placeholder="Recherche"/>
                        </li>
                    </ul>
                </nav>

            </div>

        </header>
    );
}

export default Header;
