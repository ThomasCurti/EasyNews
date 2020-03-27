import React from 'react';

// CSS
import '../Assets/scss/Article.scss';

class ArticleInfo extends React.Component{
    constructor(props) {
        super(props);

        this.state = {
            title : "Titre de l'article",
            description : "Ceci est un texte correspondant à la description d'un article.",
            full_article : "Ceci est le texte complet d'un article.",
            source : "https://www.google.com/",
        }
    }

    render() {
        return (
            <article>
                <h1 className={"title"}>
                    {this.state.title}
                </h1>
                <h4 className={"description"}>
                    {this.state.description}
                </h4>
                <div className={"full_article"}>
                    {this.state.full_article}
                </div>
                <div>
                    Sources :
                </div>
                <a className={"source"} href={this.state.source}>
                    {this.state.source}
                </a>
            </article>
        );
    }
}

export default ArticleInfo;