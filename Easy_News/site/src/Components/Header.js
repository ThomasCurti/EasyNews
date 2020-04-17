import React from 'react';

// CSS
import '../Assets/scss/Header.scss';
import {Link} from "react-router-dom";

import {searchArticles} from '../actions/Actions'
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
                                <Link to="/">Accueil</Link>
                            </li>
                            <li>
                                <Link to="/list">Dernières actualités</Link>
                            </li>
                            <li>
                                <div>Rechercher une actualité :</div>
                            </li>
                            <li>
                                <input type="text" className="form-control" placeholder="Recherche" onChange={this.onChange}/>
                            </li>
                        </ul>
                    </nav>
                </div>
            </header>
        );
    }
}

export default connect(null, {searchArticles})(Header);
