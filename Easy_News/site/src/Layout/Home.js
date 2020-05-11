import React from 'react';

// CSS
import '../Assets/scss/Home.scss';

import CircleText from '../Components/CircleText';
import ImageText from "../Components/ImageText";
import HomeBlockLeft from "../Components/HomeBlockLeft";
import HomeBlockRight from "../Components/HomeBlockRight";

const Home = () => {
    return (
        <div className="Home">
            <div className="Home_Title">Vous permet de mieux connaître l'actualité sur les crises mondiales</div>

            <HomeBlockLeft
                imageText={"Tenez vous à jour sur les crises"}
                title={"Restez à jour"}
                text={"Easy News possède un très grand nombre d'article mis à votre disposition. Toutes ces actualités vous permettront de vous tenir à jour sur les grandes crises actuelles. Easy News s'engage à vous fournir un maximum d'article venant de sources sures."}
                link={"/list"}
            />

            <HomeBlockRight
                imageText={"Apprenez à sauver le monde en jouant"}
                title={"Apprenez en jouant"}
                text={"Easy News est un site mais aussi un jeu ! En jouant avec nous, vous pourrez apprendre en vous amusant les gestes et les Actions permettant de sauver le monde ou gérer les grandes crises. Ce jeu est mis à jour régulièrement et utilise les mêmes sources d'informations que pour nos articles."}
                link={"/game"}
            />

            <CircleText text={"Aidez vos enfants"} />

            <HomeBlockLeft
                imageText={"Tenez vous à jour sur les crises"}
                title={"Aidez vos enfants à apprendre"}
                text={"Le jeu Easy News est jouable par les grands mais aussi par les petits ! En jouant à notre jeu, vous permettrez à vos jeunes proches de se renseigner sur les grands problèmes et ainsi de mieux se protéger faces à des pandémies ou face aux désastres naturelles."}
                link={"/game"}
            />

            <CircleText  text={"Qui sommes-nous ?"} />

            <div className="imagesFooter">
                <ImageText text={"Clément Dedenis"} />
                <ImageText text={"Jérémie Piro"} />
                <ImageText text={"Thomas Curti"} />
                <ImageText text={"Vincent Masson"} />
            </div>

        </div>
    );
};

export default Home;
