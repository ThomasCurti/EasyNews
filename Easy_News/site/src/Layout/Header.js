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

    return (
        <header>
            <div className="container">
                <div className="Logo">
                    <Link to="/" onClick={CancelShowSearch}>Easy News</Link>
                </div>
                <nav>
                    <ul>
                        <li>
                            <Link to="/list" onClick={CancelShowSearch}>Dernières actualités</Link>
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
