import React from 'react';

import Article from "./Article";
import {connect} from "react-redux";

// CSS
import '../Assets/scss/Article.scss';

const TOTAL_PER_PAGE = 5;

function renderListArticles(listArticles, startIndex) {
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
}

class List_articles extends React.Component{
    constructor(props) {
        super(props);

        this.state = {
            page: 0,
            totalPages: 0,
        };
        this.incrementPage = this.incrementPage.bind(this);
        this.decrementPage = this.decrementPage.bind(this);
        this.setPage = this.setPage.bind(this);
    }

    setPage(page) {
        return () => {
            this.setState({ page });
        };
    }

    decrementPage() {
        const { page } = this.state;
        this.setState({ page: page - 1 });
    }

    incrementPage() {
        const { page } = this.state;
        this.setState({ page: page + 1 });
    }

    componentDidMount(){
        const totalPages = Math.ceil(this.props.listArticles.length / TOTAL_PER_PAGE);

        this.setState({
            page: 0,
            totalPages,
        });
    }

    renderPagination(page, totalPages) {
        return (
            <div className={"list-pagination"}>
                {page !== 0 ? <button className={"pagination-left"} onClick={this.decrementPage}>
                    Précédent
                </button> : <div className={"pagination-left"}/> }
                <div> Page {page + 1} / {totalPages}</div>
                {page !== (totalPages - 1) ? <button className={"pagination-right"} onClick={this.incrementPage}>
                    Suivant
                </button> : <div className={"pagination-right"}/>}
            </div>
        );
    }

    render() {
        const { page, totalPages } = this.state;
        const startIndex = page * TOTAL_PER_PAGE;

        const listArticles = this.props.listArticles;
        const listData = renderListArticles(listArticles, startIndex);
        const pagination = this.renderPagination(page, totalPages);

        return (
            <div className={"list_article"}>
                {listData}
                {pagination}
            </div>
        );
    }
}

const mapStateToProps = state => {
    return {
        listArticles: state.listArticles,
    };
};

export default connect(mapStateToProps)(List_articles);