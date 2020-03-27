import React from 'react';

import Article from "./Article";

class List_articles extends React.Component{
    render() {
        return (
            <div className={"list_article"}>
                <Article />
                <Article />
                <Article />
                <Article />
                <Article />
            </div>
        );
    }
}

export default List_articles;