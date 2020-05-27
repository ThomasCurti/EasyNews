import React, {useCallback} from 'react';

// CSS
import '../Assets/scss/Header.scss';
import {Link} from "react-router-dom";

import {searchTextInput, showSearchNo} from '../Actions/Actions'
import {connect} from "react-redux";

const Header = ({dispatch}) => {

    const CancelShowSearch = useCallback(() => {
        dispatch(showSearchNo())
    }, [
        dispatch
    ]);

    const handleOnChange = useCallback((e) => {
        dispatch(searchTextInput(e.target.value))
    }, [
        dispatch,
    ]);

    //<Link to="/" onClick={CancelShowSearch}></Link>
    return (
        <header>
            <div className="container">

                <Link to="/">
                    <img src="logoEasyNews.png" className="Logo"/>
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
                            <input type="text" className="form-control" placeholder="Rechercher une actualité"
                                   onChange={handleOnChange}/>
                        </li>
                    </ul>
                </nav>
            </div>
        </header>
    );
};

export default connect()(Header);
