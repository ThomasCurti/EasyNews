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
            <div className={"article"}>
                <Link to={"/article/" + id} onClick={this.onClick}>
                    <h3 className={"title"}>
                        {title}
                    </h3>
                </Link>
                <div className={"description"}>
                    {description}
                </div>
            </div>
        );
    }
}

export default connect(null, {searchTextClear})(Article);