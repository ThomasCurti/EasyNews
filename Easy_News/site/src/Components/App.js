import React from 'react';

// Header and Bottom
import Header from "./Header";
import Footer from "./Footer";
import ArticleInfo from "./ArticleInfo";
import {connect} from "react-redux";

// CSS
import '../Assets/scss/Home.scss';

import {BrowserRouter, Route, Switch, Link} from "react-router-dom";

// Components
import Home from "./Home";
import List_articles from "./List_articles";
import SearchResults from "./SearchResults";

// Actions
import {getAllArticles} from "../actions/Actions";

// Client
import {client, getAllArticlesApiCall} from "../Client";

class App extends React.Component{

    /*
      Principal #FFFFFF
      Second Princiapl #F9F6F7
      Secondaire #FFE8D6
      Second Secondaire #FF971D
    * */

    componentDidMount() {
        client.get(getAllArticlesApiCall).then(res => this.props.setListArticles(res.data));
    }

    render() {

        const searchText = this.props.searchText;

        return (
            <div className="App">
                <BrowserRouter>
                    <Header />
                    {searchText === '' ? (
                        <Switch>
                            <Route exact path={"/"} component={Home} />
                            <Route path={"/list"} component={List_articles} />
                            <Route path={"/article/:id"} component={ArticleInfo} />
                        </Switch>
                    ) : (
                        <SearchResults />
                    )}

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
