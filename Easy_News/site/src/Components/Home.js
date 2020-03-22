import React from 'react';

// Header and Bottom
import Header from "./Header";
import Footer from "./Footer";

// CSS
import '../Assets/scss/Home.scss';

function Home() {
    return (
        <div className="Home">
            <Header/>

            <div className="container">
            
                <div className="row">

                    <div className="col-2">
                    <div className="dropdown">
                    <ul className="list-group">
                        <li className="list-group-item">
                            <button className="btn  dropdown-toggle" type="button" id="dropdownMenuButton1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Theme 1
                            </button>
                            <div className="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                                <a className="dropdown-item" href="/">Article 1</a>
                                <a className="dropdown-item" href="/">Article 2</a>
                                <a className="dropdown-item" href="/">Article 3</a>
                            </div>
                        </li>
                        <li className="list-group-item">
                            <button className="btn dropdown-toggle" type="button" id="dropdownMenuButton2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Theme 2
                            </button>
                            <div className="dropdown-menu" aria-labelledby="dropdownMenuButton2">
                                <a className="dropdown-item" href="/">Article 1</a>
                                <a className="dropdown-item" href="/">Article 2</a>
                                <a className="dropdown-item" href="/">Article 3</a>
                            </div>
                        </li>
                        <li className="list-group-item"><a className="dropdown-item" href="/">Article 1</a></li>
                        <li className="list-group-item">  <a className="dropdown-item" href="/">Article 2</a></li>
                        <li className="list-group-item">   <a className="dropdown-item" href="/">Article 3</a></li>
                    </ul>
                    </div>
                    </div>
                    <div className="col-1"/>
                    <div className="col-8">
                    <h1>Test homePage</h1>
                    Le Lorem Ipsum est simplement du faux texte employé dans la composition et la mise en page avant impression. Le Lorem Ipsum est le faux texte standard de l'imprimerie depuis les années 1500, quand un imprimeur anonyme assembla ensemble des morceaux de texte pour réaliser un livre spécimen de polices de texte. Il n'a pas fait que survivre cinq siècles, mais s'est aussi adapté à la bureautique informatique, sans que son contenu n'en soit modifié. Il a été popularisé dans les années 1960 grâce à la vente de feuilles Letraset contenant des passages du Lorem Ipsum, et, plus récemment, par son inclusion dans des applications de mise en page de texte, comme Aldus PageMaker.
                    </div>
                </div>
                
               
            </div>
            <Footer/>
        </div>
    );
}

export default Home;
