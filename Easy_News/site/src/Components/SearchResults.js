import {List_articles} from './List_articles';
import {connect} from "react-redux";

// CSS
import '../Assets/scss/Article.scss';
import 'semantic-ui-css/components/icon.min.css';
import 'semantic-ui-css/components/menu.min.css';


const SearchResults = ({searchListArticles, searchTotalPages, searchPage, TOTAL_PER_PAGE, dispatch}) => {

    return List_articles({listArticles: searchListArticles, totalPages: searchTotalPages, page: searchPage, TOTAL_PER_PAGE, dispatch});
};

const mapStateToProps = state => {
    return {
        searchListArticles: state.Articles.searchListArticles,
        searchTotalPages: state.Articles.searchTotalPages,
        searchPage: state.Articles.page,
        TOTAL_PER_PAGE: state.Articles.TOTAL_PER_PAGE,
    };
};

export default connect(mapStateToProps)(SearchResults);