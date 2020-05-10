import React from "react";
import {Link} from "react-router-dom";

// CSS
import '../Assets/scss/Article.scss';

import {connect} from "react-redux";

// Actions
import {searchTextClear} from '../actions/Actions'

class Article extends React.Component {
    constructor(props) {
        super(props);
    }

    onClick = () => {
        this.props.searchTextClear();
    };

    render() {
        const id = this.props.id;
        const title = this.props.title;
        const  description = this.props.description;

        return (
            <Link className="articleLinkTo" to={"/article/" + id} onClick={this.onClick}>

                <div className="article">
                    <h3>
                        <div className="title">
                            {title}
                        </div>
                    </h3>
                    <div className="description">
                        {description}
                    </div>
                </div>

            </Link>
        );
    }
}

export default connect(null, {searchTextClear})(Article);