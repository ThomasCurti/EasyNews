import React from 'react';

import {renderListArticles} from './List_articles';
import {connect} from "react-redux";

// CSS
import '../Assets/scss/Article.scss';
import 'semantic-ui-css/components/icon.min.css';
import 'semantic-ui-css/components/menu.min.css';

// semantic
import { Menu, Icon } from 'semantic-ui-react';
import times from 'lodash.times';

// Actions
import {Pagination_UP, Pagination_DOWN, Pagination_RESET, Pagination_SET} from "../Actions/Actions";

class SearchResults extends React.Component{

    componentDidMount() {
        this.props.Pagination_RESET()
    }

    decrementPage = () => {
        this.props.Pagination_DOWN()
    };

    incrementPage = () => {
        this.props.Pagination_UP()
    };

    setPage = (page) => {
        this.props.Pagination_SET(page);
    };

    renderPagination(page, totalPages) {
        return(
            <Menu floated="right" pagination>
                {page !== 0 && <Menu.Item as="a" icon onClick={this.decrementPage}>
                    <Icon name="left chevron" />
                </Menu.Item>}
                {times(totalPages, n =>
                    (<Menu.Item as="a" key={n} active={n === page} onClick={() => this.setPage(n)}>
                        {n + 1}
                    </Menu.Item>),
                )}
                {page !== (totalPages - 1) && <Menu.Item as="a" icon onClick={this.incrementPage}>
                    <Icon name="right chevron" />
                </Menu.Item>}
            </Menu>
        );
    }

    render() {
        const { searchPage, searchTotalPages, TOTAL_PER_PAGE } = this.props;
        const startIndex = searchPage * TOTAL_PER_PAGE;

        const searchListArticles = this.props.searchListArticles;
        const listData = renderListArticles(searchListArticles, startIndex, TOTAL_PER_PAGE);
        const pagination = this.renderPagination(searchPage, searchTotalPages);

        return (
            <div className={"list_article"}>
                {listData}
                {searchTotalPages !== 1 && pagination}
            </div>
        );
    }
}

const mapStateToProps = state => {
    return {
        searchListArticles: state.Articles.searchListArticles,
        searchTotalPages: state.Articles.searchTotalPages,
        searchPage: state.Articles.page,
        TOTAL_PER_PAGE: state.Articles.TOTAL_PER_PAGE,
    };
};

export default connect(mapStateToProps, {Pagination_UP, Pagination_DOWN, Pagination_RESET, Pagination_SET})(SearchResults);