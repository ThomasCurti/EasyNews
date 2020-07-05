import React from 'react';

// Header and Bottom
import Header from "./Header";
import ArticleInfo from "./ArticleInfo";
import {connect} from "react-redux";

// CSS
import '../Assets/scss/Home.scss';

import {BrowserRouter, Route, Switch} from "react-router-dom";

// Components
import Home from "./Home";
import List_articles from "../Components/List_articles";
import SearchResults from "../Components/SearchResults";

import GamePage from "./GamePage";

const App = ({showSearchArticles}) => {

    return (
        <div className="App">
            <BrowserRouter>
                <Header />

                <div className={"container"}>
                    {!showSearchArticles ? (
                        <Switch>
                            <Route exact path={"/"} component={Home} />
                            <Route path={"/list"} component={List_articles} />
                            <Route path={"/article/:id"} component={ArticleInfo} />
                            <Route path={"/game"} component={GamePage} />
                        </Switch>
                    ) : (
                        <SearchResults />
                    )}
                </div>
            </BrowserRouter>
        </div>
    );
};

const mapStateToProps = state => {
    return {
        showSearchArticles: state.Articles.showSearchArticles,
    };
};


export default connect(mapStateToProps)(App);
