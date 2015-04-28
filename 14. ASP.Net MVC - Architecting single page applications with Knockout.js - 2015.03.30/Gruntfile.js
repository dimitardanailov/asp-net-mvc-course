module.exports = function (grunt) {
  
  grunt.initConfig({
    uglify: {
      options: {
        mangle: true,
        compress: true,
        sourceMap: "dist/application.map",
        banner: "/* Dimitar Danailov 2015 */\n"
      },
      target: {
        src: "dest/application.js",
        dest: "dist/application.min.js"
      },
    }, // END uglify
    jshint: {
      options: {
        jshintrc: ".jshintrc"
      },
      target: {
        src: "src/*.js"
      }
    }, // END jshint
    concat: {
      options: {
        seperator: ";",
        banner: "/* Dimitar Danailov 2015 */\n"
      },
      target: {
        src: "lib/*.js",
        dest: "dest/application.js"
      }
    }, // END concat
    coffee: {
      options: {
        bare: false,
        join: false,
        seperator: ";"
      },
      target: {
        expand: true,
        cwd: 'lib/',
        src: '*.coffee',
        dest: 'lib/',
        ext: ".js"
      }
    }, // END coffee
  });

  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-jshint');
  grunt.loadNpmTasks('grunt-contrib-concat');
  // grunt.loadNpmTasks('grunt-contrib-watch');
  grunt.loadNpmTasks('grunt-contrib-coffee');
  // grunt.loadNpmTasks('grunt-contrib-nodeunit');
  // grunt.loadNpmTasks('grunt-contrib-clean');

  grunt.registerTask("default", ['coffee', 'jshint', 'concat', 'uglify']);
};