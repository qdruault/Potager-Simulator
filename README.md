# Potager Simulator

Le Projet *Potager Simulator* a été développé au sein de mon cursus d'ingénieur à l'UTC. Le concept est de proposer un environnement virtuel permettant de simuler la culture de plantes dans une station spatiale futuriste. L’utilisateur sera en mesure, de creuser, planter, arroser, récolter les plantes, mais aussi manipuler le matériel de la station pour modifier le développement des plantes ou encore la météo de la station.

## Matériel utilisé

Nous avons choisi de développer ce projet sous Unity et de le déployer sur le casque HTC Vive. Nous trouvons que le casque apporte un sentiment d’immersion plus important que le CAVE. De plus, le casque étant plus facile d’acquisition pour les entreprises, il nous paraît plus pertinent d’obtenir une expérience avec cette technologie. Enfin, même s’il nous paraît compliqué de l’ajouter au sein de notre projet dans le temps imparti, le casque pourrait nous permettre d’ajouter une seconde personne dans l’espace virtuel, pour apporter un aspect coopération à l’expérience.

Comme nous utilisons le casque HTC Vive, nous pouvons utiliser ses manettes comme dispositif d’interaction. Celles-ci permettent le tracking des mains de l’utilisateur et présentent un certain nombre de boutons que nous pourrons utiliser.

## Scénario

Le joueur est dans une serre futuriste. Les éléments d'une serre classique y sont présents : graines, arrosoir, pelle, blocs de terre, etc. La particularité de cette serre est son tableau de bord permettant la gestion de la température et de la luminosité de la serre.

Le but du joueur est de réussir à faire pousser des fruits et des légumes. Des indications le guide au cours de ce processus. Il y a trois niveaux de difficulté dans ce jeu. 

Le scénario commence au niveau le plus simple, la plante doit simplement être arrosée pour pousser. Puis, pour la seconde plante, l’utilisateur doit modifier les valeurs des variables environnementales afin qu’elles correspondent aux valeurs optimales de poussée de la plante. Enfin, il existe un dernier niveau, mettant en jeu des mauvaises herbes. Celles-ci vont apparaître de manière aléatoire sur les blocs de terre et devront être retirées à la main sous peine de gêner le développement de la plante. L’état de la plante obtenu à la fin de sa croissance est fonction d’un score de malus. Plus la plante passe de temps dans des conditions non favorables (présence de mauvaises herbes, mauvais conditions environnementales), plus le score de malus va augmenter, et moins son état sera bon à la fin de sa croissance.

## Images du jeu

![Tableau de contrôle](https://github.com/qdruault/Potager-Simulator/blob/master/RV01/Assets/screenshots/tableau_de_controle.PNG "Tableau de contrôle")
![Pelle](https://github.com/qdruault/Potager-Simulator/blob/master/RV01/Assets/screenshots/pelle.PNG "Pelle")
![Radis](https://github.com/qdruault/Potager-Simulator/blob/master/RV01/Assets/screenshots/radis.PNG "Radis")

## Démonstration



## Notes

Ceci reste un projet scolaire répondant à un cadre et à des délais précis. Beaucoup d'améliorations peuvent être apportées à cette application (ajout d'un deuxième joueur, variation des conditions météo, meilleur réalisme des interactions, etc.). Merci à l'UTC pour la mise à disposition d'une salle immersive et du prêt des casques HTC Vive qui nous ont permis le développement de notre première application de réalité virtuelle.


## Auteurs

Projet développé dans le cadre de l'UV RV01 à l'UTC par Baptiste DE FILIPPIS et Quentin DRUAULT-AUBIN.
