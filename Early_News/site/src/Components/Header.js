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
                            <a href="/">Lien 1</a>
                        </li>
                        <li>
                            <a href="/">Lien 2</a>
                        </li>
                        <li>
                            <a href="/">Lien 3</a>
                        </li>
                        <li>
                            <a href="/">Lien 4</a>
                        </li>
                    </ul>
                </nav>

            </div>

        </header>
    );
}

export default Header;
