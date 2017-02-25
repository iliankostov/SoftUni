var imdb = imdb || {};

(function (scope) {
	function loadHtml(selector, data) {
		var container = document.querySelector(selector),
			moviesContainer = document.getElementById('movies'),
			detailsContainer = document.getElementById('details'),
			genresUl = loadGenres(data);

		container.appendChild(genresUl);

		genresUl.addEventListener('click', function (ev) {
			if (ev.target.tagName === 'LI') {
				var genreId,
					genre,
					moviesHtml;

				genreId = parseInt(ev.target.getAttribute('data-id'));
				genre = data.filter(function (genre) {
					return genre._id === genreId;
				})[0];

				moviesHtml = loadMovies(genre.getMovies());
				moviesContainer.innerHTML = moviesHtml.outerHTML;
				moviesContainer.setAttribute('data-genre-id', genreId);
			}
		});

		// Task 2 - Add event listener for movies boxes

		// TODO: event listener

		function loadActors(actors) {
			var actorsUl = document.createElement('ul');
			actors.forEach(function (actor) {
				var liActor = document.createElement('li');
				liActor.setAttribute('data-id', actor._id);

				liActor.innerHTML = '<h4>' + actor.name + '<h4>';
				liActor.innerHTML += '<div><span>Bio:</span>' + actor.bio + '</div>';
				liActor.innerHTML += '<div><span>Born:</span>' + actor.born + '</div>';

				actorsUl.appendChild(liActor);
			});
		}

		function loadReviews(reviews) {
			var reviewsUl = document.createElement('ul');
			reviews.forEach(function (review) {
				var liReview = document.createElement('li');
				liReview.setAttribute('data-id', review._id);

				liReview.innerHTML = '<h4>' + review.author + '<h4>';
				liReview.innerHTML += '<div><span>Content:</span>' + review.content + '</div>';
				liReview.innerHTML += '<div><span>Date:</span>' + review.date + '</div>';

				reviewsUl.appendChild(liReview);
			});
		}

		// Task 3 - Add event listener for delete button (delete movie button or delete review button)
	}

	function loadGenres(genres) {
		var genresUl = document.createElement('ul');
		genresUl.setAttribute('class', 'nav navbar-nav');
		genres.forEach(function (genre) {
			var liGenre = document.createElement('li');
			liGenre.innerHTML = genre.name;
			liGenre.setAttribute('data-id', genre._id);
			genresUl.appendChild(liGenre);
		});

		return genresUl;
	}

	function loadMovies(movies) {
		var moviesUl = document.createElement('ul');
		movies.forEach(function (movie) {
			var liMovie = document.createElement('li');
			liMovie.setAttribute('data-id', movie._id);

			liMovie.innerHTML = '<h3>' + movie.title + '</h3>';
			liMovie.innerHTML += '<div>Country: ' + movie.country + '</div>';
			liMovie.innerHTML += '<div>Time: ' + movie.length + '</div>';
			liMovie.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
			liMovie.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
			liMovie.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';
			
			moviesUl.appendChild(liMovie);
		});

		return moviesUl;
	}

	scope.loadHtml = loadHtml;
}(imdb));