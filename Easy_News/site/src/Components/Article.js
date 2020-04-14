import React from "react";
import {Link} from "react-router-dom";

// CSS
import '../Assets/scss/Article.scss';

function Article(props) {
    const id = props.id;
    const title = props.title;
    const  description = props.description;

    return (
        <div className={"article"}>
            <Link to={"/article/" + id}>
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

export default Article;