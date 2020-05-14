import React from 'react';
import {connect} from "react-redux";

// CSS
import '../Assets/scss/ArticleInfo.scss';

// Router
import {Link} from "react-router-dom";

function renderArticle(article) {
    return article ? (
        <article>
            <h1 className="titleInfo">
                {article.title}
            </h1>
            <h4 className="descriptionInfo">
                {article.description}
            </h4>
            <div className="fullArticleInfo">
                {article.full_article}
            </div>
        </article>
    ) : (
        <p>L'article n'existe pas</p>
    );
}

function renderPagination(article, length) {
    const id = article.id;

    const previousArticleId = id - 1;
    const nextArticleId = id + 1;

    const previousArticleLink = previousArticleId !== 0 ? "/article/" + previousArticleId : "/";
    const nextArticleLink = nextArticleId !== length ? "/article/" + nextArticleId : "/";

    const previousArticleText = "< Article précédent";
    const nextArticleText = "Article suivant >";

    const previousArticle = previousArticleLink === "/" ? <div/> : (<Link to={previousArticleLink}>{previousArticleText}</Link>);
    const nextArticle = nextArticleLink === "/" ? <div/> : (<Link to={nextArticleLink}>{nextArticleText}</Link>);

    return (
        <div className="pagination">
            <div className="previous paginationArrow">{previousArticle}</div>
            <div className="next paginationArrow">{nextArticle}</div>
        </div>
    );

}

class ArticleInfo extends React.Component{

    render() {
        const article = renderArticle(this.props.article);
        const pagination = this.props.article ? renderPagination(this.props.article, this.props.length) : (<div/>);

        return (<div>
            <aside>
                {pagination}
            </aside>
            {article}
        </div>);
    }
}

const mapStateToProps = (state, ownProps) => {
    let article_id = ownProps.match.params.id;
    const article = state.Articles.listArticles.find(article => article.id.toString() === article_id);
    if (article){
        return { article : article, length : state.Articles.listArticles.length + 1}
    }
    else{
        return {}
    }
};

export default connect(mapStateToProps)(ArticleInfo);