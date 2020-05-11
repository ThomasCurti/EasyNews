import React from 'react';

// CSS
import '../Assets/scss/Header.scss';
import {Link} from "react-router-dom";

import {searchArticles} from '../Actions/Actions'
import {connect} from "react-redux";

class Header extends React.Component{

    onChange = e => {
        this.props.searchArticles(e.target.value)
    };

    render(){
        return (
            <header>
                <div className="container">
                    <div className="Logo">
                        <Link to="/">Easy News</Link>
                    </div>
                    <nav>
                        <ul>
                            <li>
                                <Link to="/list">Dernières actualités</Link>
                            </li>
                            <li>
                                <Link to="/game">Easy News le jeu</Link>
                            </li>
                            <li>
                                <input type="text" className="form-control" placeholder="Rechercher une actualité" onChange={this.onChange}/>
                            </li>
                        </ul>
                    </nav>
                </div>
            </header>
        );
    }
}

export default connect(null, {searchArticles})(Header);
