import React from "react";
import {Link} from "react-router-dom";

// CSS
import '../Assets/scss/Article.scss';

import {connect} from "react-redux";

// Actions
import {searchTextClear} from '../Actions/Actions'

class Article extends React.Component {

    onClick = () => {
        this.props.searchTextClear();
    };

    render() {
        const id = this.props.id;
        const title = this.props.title;
        const  description = this.props.description;

        return (
                <div className="article">
                    <h3>
                        <Link className="articleLinkTo" to={"/article/" + id} onClick={this.onClick}>
                        <div className="title">
                            {title}
                        </div>
                        </Link>
                    </h3>
                    <div className="description">
                        {description}
                    </div>
                </div>
        );
    }
}

export default connect(null, {searchTextClear})(Article);