import React from 'react';

// Header and Bottom
import Header from "./Header";
import Footer from "./Footer";
import ArticleInfo from "./ArticleInfo";
import {connect} from "react-redux";

// CSS
import '../Assets/scss/Home.scss';

import {BrowserRouter, Route, Switch, Link} from "react-router-dom";
import Home from "./Home";
import List_articles from "./List_articles";
import {getAllArticles} from "../actions/Actions";
import {client, getAllArticlesApiCall} from "../Client";

class App extends React.Component{

    componentDidMount() {
        client.get(getAllArticlesApiCall).then(res => this.props.setListArticles(res.data));
    }

    render() {
        return (
            <div className="App">
                <BrowserRouter>
                    <Header/>
                    <div className="container">
                        <div className="row">
                            <div className="col-2">
                                <div className="dropdown">
                                    <ul className="list-group">
                                        <li className="list-group-item">
                                            <button className="btn  dropdown-toggle" type="button" id="dropdownMenuButton1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Theme 1
                                            </button>
                                            <div className="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                                                <Link className="dropdown-item" to="/article/1">Article 1</Link>
                                                <Link className="dropdown-item" to="/article/2">Article 2</Link>
                                                <Link className="dropdown-item" to="/article/3">Article 3</Link>
                                            </div>
                                        </li>
                                        <li className="list-group-item">
                                            <button className="btn dropdown-toggle" type="button" id="dropdownMenuButton2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Theme 2
                                            </button>
                                            <div className="dropdown-menu" aria-labelledby="dropdownMenuButton2">
                                                <Link className="dropdown-item" to="/article/1">Article 1</Link>
                                                <Link className="dropdown-item" to="/article/2">Article 2</Link>
                                                <Link className="dropdown-item" to="/article/3">Article 3</Link>
                                            </div>
                                        </li>
                                        <li className="list-group-item"><Link className="dropdown-item" to="/article/1">Article 1</Link></li>
                                        <li className="list-group-item"><Link className="dropdown-item" to="/article/2">Article 2</Link></li>
                                        <li className="list-group-item"><Link className="dropdown-item" to="/article/3">Article 3</Link></li>
                                    </ul>
                                </div>
                            </div>
                            <div className="col-1"/>
                            <div className="col-8">

                                <Switch>
                                    <Route exact path={"/"} component={Home} />
                                    <Route path={"/list"} component={List_articles} />
                                    <Route path={"/article/:id"} component={ArticleInfo} />
                                </Switch>

                            </div>
                        </div>
                    </div>
                    <Footer/>
                </BrowserRouter>
            </div>
        );
    }
}

const mapStateToProps = state => {
    return {
        listArticles: state.listArticles,
    };
};

const mapDispatchToProps = dispatch => {
    return {
        setListArticles: data => dispatch(getAllArticles(data))
    }
};

export default connect(mapStateToProps, mapDispatchToProps)(App);
