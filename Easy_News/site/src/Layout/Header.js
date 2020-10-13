import React, {useCallback} from 'react';

// CSS
import '../Assets/scss/Header.scss';
import {Link} from "react-router-dom";

// img
import logoEasyNews from '../../public/logoEasyNews.png';

import {searchTextInput, showSearchNo} from '../Actions/Actions'
import {connect} from "react-redux";

const Header = ({dispatch}) => {

    const CancelShowSearch = useCallback(() => {
        dispatch(showSearchNo());
        document.getElementById('researchInput').value = '';
    }, [
        dispatch
    ]);

    const handleOnChange = useCallback((e) => {
        dispatch(searchTextInput(e.target.value))
    }, [
        dispatch,
    ]);

    return (
        <header>
            <div className="container">

                <Link to="/" onClick={CancelShowSearch}>
                    <img src={logoEasyNews} className="Logo" alt={"logo"}/>
                </Link>
                <nav>
                    <ul>
                        <li>
                            <Link to="/" onClick={CancelShowSearch}>Accueil</Link>
                        </li>
                        <li>
                            <Link to="/list" onClick={CancelShowSearch}>Actualités</Link>
                        </li>
                        <li>
                            <Link to="/game" onClick={CancelShowSearch}>Easy News le jeu</Link>
                        </li>
                        <li>
                            <input id={"researchInput"} type="text" className="form-control" placeholder="Rechercher une actualité"
                                   onFocus={CancelShowSearch}
                                   onChange={handleOnChange}/>
                        </li>
                    </ul>
                </nav>
            </div>
        </header>
    );
};

export default connect()(Header);
