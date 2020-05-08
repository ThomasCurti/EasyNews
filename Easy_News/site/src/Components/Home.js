import React from 'react';

// CSS
import '../Assets/scss/Home.scss';
import {Link} from "react-router-dom";

function Home() {
    return (
        <div className="Home">
            <div>
                <div className="Home_Title">Vous permet de mieux connaître l'actualité sur les crises mondiales</div>
            </div>

            <div className="homeBlock">
                <div className="homeBlockLeft">
                    <div className="homeBlockText">Tenez vous à jour sur les crises</div>
                    <image className="homeBlockImage"></image>
                </div>
                <div className="homeBlockTextLeft">
                    <div className="homeBlockTextSubtitle">Restez à jour</div>
                    <div className="homeBlockTextText">Easy News possède un très grand nombre d'article mis à votre disposition. Toutes ces actualités vous permettront de vous tenir à jour sur les grandes crises actuelles. Easy News s'engage à vous fournir un maximum d'article venant de sources sures.</div>
                    <Link className="homeBlockTextLink" to="/list">En savoir plus ></Link>
                </div>
            </div>

            <div className="homeBlock">
                <div className="homeBlockRight">
                    <div className="homeBlockText">Apprenez à sauver le monde en jouant</div>
                    <image className="homeBlockImage"></image>
                </div>
                <div className="homeBlockTextRight">
                    <div className="homeBlockTextSubtitle">Apprenez en jouant</div>
                    <div className="homeBlockTextText">Easy News est un site mais aussi un jeu ! En jouant avec nous, vous pourrez apprendre en vous amusant les gestes et les actions permettant de sauver le monde ou gérer les grandes crises. Ce jeu est mis à jour régulièrement et utilise les mêmes sources d'informations que pour nos articles.</div>
                    <Link className="homeBlockTextLink" to="/list">En savoir plus ></Link>
                </div>
            </div>

            <div className="line">
                <div className="circle">
                    <div className="circleText">
                        Aidez vos enfants
                    </div>
                </div>
            </div>

            <div className="homeBlock">
                <div className="homeBlockLeft">
                    <div className="homeBlockText">Tenez vous à jour sur les crises</div>
                    <image className="homeBlockImage"></image>
                </div>
                <div className="homeBlockTextLeft">
                    <div className="homeBlockTextSubtitle">Aidez vos enfants à apprendre</div>
                    <div className="homeBlockTextText">Le jeu Easy News est jouable par les grands mais aussi par les petits ! En jouant à notre jeu, vous permettrez à vos jeunes proches de se renseigner sur les grands problèmes et ainsi de mieux se protéger faces à des pandémies ou face aux désastres naturelles.</div>
                    <Link className="homeBlockTextLink" to="/list">En savoir plus ></Link>
                </div>
            </div>

            <div className="line">
                <div className="circle">
                    <div className="circleText">
                        Qui sommes-nous ?
                    </div>
                </div>
            </div>

            <div className="imagesFooter">
                <ul>
                    <li>
                        <image className="imagesFooterImage"></image>
                        <div className="imagesFooterText">Clément Dedenis</div>
                    </li>
                    <li>
                        <image className="imagesFooterImage"></image>
                        <div className="imagesFooterText">Jérémie Piro</div>
                    </li>
                    <li>
                        <image className="imagesFooterImage"></image>
                        <div className="imagesFooterText">Thomas Curti</div>
                    </li>
                    <li>
                        <image className="imagesFooterImage"></image>
                        <div className="imagesFooterText">Vincent Masson</div>
                    </li>
                </ul>
            </div>

        </div>
    );
}

export default Home;
