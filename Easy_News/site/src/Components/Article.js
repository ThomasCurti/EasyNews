import React from "react";
import {Link} from "react-router-dom";

// CSS
import '../Assets/scss/Article.scss';

class Article extends React.Component{
    constructor(props) {
        super(props);

        this.state= {
            title : "Titre de l'article",
            description : "Ceci est un texte correspondant à la description d'un article.",
        }
    }

    render() {
        return (
            <div className={"article"}>
                <Link to={"/article/1"}>
                    <h3 className={"title"}>
                        {this.state.title}
                    </h3>
                </Link>
                <div className={"description"}>
                    {this.state.description}
                </div>
            </div>
        );
    }
}

export default Article;