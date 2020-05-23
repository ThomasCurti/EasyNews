import React, {useCallback} from "react";
import {Link} from "react-router-dom";

// CSS
import '../Assets/scss/Article.scss';

import {connect} from "react-redux";

// Actions
import {showSearchNo} from '../Actions/Actions'

const Article = ({id, title, description, dispatch}) => {

    const CancelShowSearch = useCallback(() => {dispatch(showSearchNo())}, [dispatch]);

    return (
        <div className="article">
            <h3>
                <Link className="articleLinkTo" to={"/article/" + id} onClick={CancelShowSearch}>
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
};

export default connect()(Article);