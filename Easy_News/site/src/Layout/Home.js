import React from 'react';
import Carousel from 'react-bootstrap/Carousel';

// CSS
import '../Assets/scss/Home.scss';

import CircleText from '../Components/CircleText';
import ImageText from "../Components/ImageText";
import HomeBlockLeft from "../Components/HomeBlockLeft";
import HomeBlockRight from "../Components/HomeBlockRight";
import {Link} from "react-router-dom";

const Home = () => {
    return (
        <div className="Home">
            <div className="Home_Title">Mieux connaître l'actualité sur les crises mondiales</div>

            <Carousel className="carousel">
                <Carousel.Item>
                    <div>
                        <div className="carouselContainer">
                            <h2>Restez à jour</h2>
                            <h5>Tenez vous à jour sur les crises</h5>
                            <Link to="/list">
                                <p className="carouselContainerSubtitle">En savoir plus ></p>
                            </Link>
                        </div>
                        <img
                            className="d-block w-100 carouselImage"
                            src="BackgroundAccueil.png"
                            alt="First slide"
                        />
                    </div>
                    <Carousel.Caption>
                        <p className="carouselCaption">Easy News possède un très grand nombre d'article mis à votre disposition. Toutes ces
                            actualités vous permettront de vous tenir à jour sur les grandes crises actuelles. Easy News
                            s'engage à vous fournir un maximum d'article venant de sources sures.</p>
                    </Carousel.Caption>
                </Carousel.Item>

                <Carousel.Item>

                    <div>
                        <div className="carouselContainer">
                            <h2>Apprenez en jouant</h2>
                            <h5>Apprenez à sauver le monde en jouant</h5>
                            <Link to="/game">
                                <p className="carouselContainerSubtitle">En savoir plus ></p>
                            </Link>
                        </div>
                        <img
                            className="d-block w-100 carouselImage"
                            src="BackgroundAccueil.png"
                            alt="First slide"
                        />
                    </div>
                    <Carousel.Caption>
                        <p className="carouselCaption">Easy News est un site mais aussi un jeu ! En jouant avec nous, vous pourrez apprendre en vous
                            amusant les gestes et les Actions permettant de sauver le monde ou gérer les grandes crises.
                            Ce jeu est mis à jour régulièrement et utilise les mêmes sources d'informations que pour nos
                            articles.</p>
                    </Carousel.Caption>
                </Carousel.Item>
            </Carousel>

            <h3 className="subTitle">Aidez vos enfants</h3>

            <HomeBlockLeft
                imageText={"Jouez et apprenez"}
                title={"Aidez vos enfants à apprendre"}
                text={"Le jeu Easy News est jouable par les grands mais aussi par les petits ! En jouant à notre jeu, vous permettrez à vos jeunes proches de se renseigner sur les grands problèmes et ainsi de mieux se protéger faces à des pandémies ou face aux désastres naturelles."}
                link={"/game"}
            />

            <h3 className="subTitle">Qui sommes nous ?</h3>

            <div>
                <div className="imagesFooter">
                    <ImageText text={"Clément Dedenis"}/>
                    <ImageText text={"Jérémie Piro"}/>
                    <ImageText text={"Thomas Curti"}/>
                    <ImageText text={"Vincent Masson"}/>
                </div>
            </div>

        </div>
    );
};

export default Home;
