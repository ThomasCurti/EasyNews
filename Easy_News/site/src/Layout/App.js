import React from 'react';

// Header and Bottom
import Header from "./Header";
import Footer from "./Footer";
import ArticleInfo from "./ArticleInfo";
import {connect} from "react-redux";

// CSS
import '../Assets/scss/Home.scss';

import {BrowserRouter, Route, Switch} from "react-router-dom";

// Components
import Home from "./Home";
import List_articles from "../Components/List_articles";
import SearchResults from "../Components/SearchResults";

// Actions
import {getAllArticles} from "../Actions/Actions";

// Client
import {client, getAllArticlesApiCall} from "../Client";
import GamePage from "./GamePage";

class App extends React.Component{

    componentDidMount() {
        client.get(getAllArticlesApiCall).then(res => this.props.setListArticles(res.data));
    }

    render() {

        const searchText = this.props.searchText;

        return (
            <div className="App">
                <BrowserRouter>
                    <Header />

                    <div className={"container"}>
                        {searchText === '' ? (
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

                    <Footer/>
                </BrowserRouter>
            </div>
        );
    }
}

const mapStateToProps = state => {
    return {
        listArticles: state.Articles.listArticles,
        searchText: state.Articles.searchText,
    };
};

const mapDispatchToProps = dispatch => {
    return {
        setListArticles: data => dispatch(getAllArticles(data))
    }
};

export default connect(mapStateToProps, mapDispatchToProps)(App);
