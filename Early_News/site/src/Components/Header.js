import React from 'react';

// CSS
import '../Assets/scss/Header.scss';

function Header() {
    return (
        <header>

            <div className="container">
                <div className="Logo">
                    <a href="/">Easy News</a>
                </div>

                <nav>
                    <ul>
                        <li>
                            <a href="/">Accueil</a>
                        </li>
                        <li>
                            <a href="/">Dernière actualité</a>
                        </li>
                        <li>
                            <div>Rechercher une actualité :</div>
                        </li>
                        <li></li>
                        <li>
                        <input type="text" class="form-control" placeholder="Recherche"/>
                        </li>
                    </ul>
                </nav>

            </div>

        </header>
    );
}

export default Header;
