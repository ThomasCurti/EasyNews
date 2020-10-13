import React from 'react';

import Article from "./Article";
import {connect} from "react-redux";

// CSS
import '../Assets/scss/Article.scss';
import 'semantic-ui-css/components/icon.min.css';
import 'semantic-ui-css/components/menu.min.css';

// semantic
import { Menu, Icon } from 'semantic-ui-react';
import times from 'lodash.times';

import {Pagination_UP, Pagination_DOWN, Pagination_SET} from "../Actions/Actions";

const renderListArticles = (listArticles, startIndex, TOTAL_PER_PAGE) => {
    const listData = listArticles.length ? (
        listArticles.slice(startIndex, startIndex + TOTAL_PER_PAGE).map((article, key) => {
            return (
                <Article id={article.id} title={article.title} description={article.description} key={key}/>
            );
        })
    ): (
        <p>Aucun articles pour le moment.</p>
    );
    return (
        <div className={"list_article"}>
            {listData}
        </div>
    );
};

const renderPagination = (page, totalPages, decrementPage, setPage, incrementPage) => {
    return(
        <Menu floated="right" pagination>
            {page !== 0 && <Menu.Item as="a" icon onClick={decrementPage}>
                <Icon name="left chevron" />
            </Menu.Item>}
            {times(totalPages, n =>
                (<Menu.Item as="a" key={n} active={n === page} onClick={() => setPage(n)}>
                    {n + 1}
                </Menu.Item>),
            )}
            {page !== (totalPages - 1) && <Menu.Item as="a" icon onClick={incrementPage}>
                <Icon name="right chevron" />
            </Menu.Item>}
        </Menu>
    );
};

export const List_articles = ({listArticles, page, totalPages, TOTAL_PER_PAGE, dispatch}) => {

    const decrementPage = () => {
        dispatch(Pagination_DOWN());
    };

    const incrementPage = () => {
        dispatch(Pagination_UP());
    };

    const setPage = (page) => {
        dispatch(Pagination_SET(page));
    };

    const startIndex = page * TOTAL_PER_PAGE;
    const listData = renderListArticles(listArticles, startIndex, TOTAL_PER_PAGE);
    const pagination = renderPagination(page, totalPages, decrementPage, setPage, incrementPage);

    return (
        <div className={"list_article"}>
            {listData}
            {totalPages !== 1 && pagination}
        </div>
    );
};

const mapStateToProps = state => {
    return {
        listArticles: state.Articles.listArticles,
        totalPages: state.Articles.totalPages,
        page: state.Articles.page,
        TOTAL_PER_PAGE: state.Articles.TOTAL_PER_PAGE,
    };
};

export default connect(mapStateToProps)(List_articles);