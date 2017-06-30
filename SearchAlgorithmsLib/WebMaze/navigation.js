var menuLinks = '';

menuLinks += '<nav class="navbar navbar-inverse">';
menuLinks += '<div class="container-fluid">';
menuLinks += '<div class="navbar-header">';
menuLinks += '<a class="navbar-brand" href="http://localhost:58603/OpeningScreen.html">The Maze</a>';
menuLinks += '</div>';
menuLinks += '<ul class="nav navbar-nav">';
menuLinks += '<li class="active"><a href="http://localhost:58603/OpeningScreen.html">Home</a></li>';
menuLinks += '<li><a href="http://localhost:58603/SinglePlayerPage.html">Single Player</a></li>';
menuLinks += '<li><a href="#">Multy Player</a></li>';
menuLinks += '<li><a href="http://localhost:58603/Settings.html">Settings</a></li>';
menuLinks += '</ul>';
menuLinks += '<ul class="nav navbar-nav navbar-right">';
menuLinks += '<li><a href="http://localhost:58603/RegisterScreen.html"><span class="glyphicon glyphicon-user"></span> Sign Up</a></li>';
menuLinks += '<li><a href="http://localhost:58603/LoginScreen.html"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>';
menuLinks += '</ul>';
menuLinks += '</div>';
menuLinks += '</nav>';

document.write(menuLinks);