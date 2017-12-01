/// <binding BeforeBuild='clean, compile, autoprefix, min' />
"use strict";

var gulp = require('gulp'),
	autoprefixer = require('autoprefixer'),
	rimraf = require('rimraf'),
	concat = require('gulp-concat'),
	cssmin = require('gulp-cssmin'),
	postcss = require('gulp-postcss'),
	sass = require('gulp-sass'),
	uglify = require('gulp-uglify');

var webroot = "./wwwroot/";
var paths = {
	scss: webroot + "scss/**/*.scss",
	scssDest: webroot + "css/",
	js: webroot + "js/**/*.js",
	minJs: webroot + "js/**/*.min.js",
	css: webroot + "css/**/*.css",
	preCss: webroot + "css/site.css",
	preCssDest: webroot + "css",
	minCss: webroot + "css/**/*.min.css",
	concatJsDest: webroot + "js/site.min.js",
	concatCssDest: webroot + "css/freelancer.min.css"
};

gulp.task("compile:scss", function () {
	gulp.src(paths.scss)
		.pipe(sass())
		.pipe(gulp.dest(paths.scssDest));
});

gulp.task("compile", ["compile:scss"]);

gulp.task("watch:scss", function () {
	gulp.watch(paths.scss, ["compile:scss"]);
});

gulp.task("watch", ["watch:scss"]);

gulp.task('clean:js', function (cb) {
	rimraf(paths.concatJsDest, cb);
});

gulp.task('clean:css', function (cb) {
	rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
	return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
		.pipe(concat(paths.concatJsDest))
		.pipe(uglify())
		.pipe(gulp.dest("."));
});

gulp.task("autoprefix:css", function () {
	return gulp.src(paths.preCss)
		.pipe(postcss([autoprefixer()]))
		.pipe(gulp.dest(paths.preCssDest));
})

gulp.task("min:css", function () {
	return gulp.src([paths.css, "!" + paths.minCss])
		.pipe(concat(paths.concatCssDest))
		.pipe(cssmin())
		.pipe(gulp.dest("."));
});

gulp.task("autoprefix", ["autoprefix:css"]);

gulp.task("min", ["min:js", "min:css"]);