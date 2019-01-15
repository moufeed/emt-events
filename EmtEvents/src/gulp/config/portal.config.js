var portal_dist = "./wwwroot/portal";
var portal_src = "./src/portal";



module.exports = {
    dist : portal_dist,
    src : portal_src,
    header: '/*!\n* <%= pkg.name %> - v <%= pkg.version %> \n* <%= pkg.description %> \n* Author :<%= pkg.author %>\n*/\n',
    sassOptions: {
        outputStyle: 'compressed'
    },
    fonts: [{
        output: `${portal_dist}/fonts/fa/`,
        input: [
            './node_modules/font-awesome/fonts/*',
        ]
    }, {
        output: `${portal_dist}/fonts/`,
        input: [`${portal_src}/fonts/**/*`]
    }],
    css: {
        src: [
            `${portal_src}/scss/**/*.scss`
        ],
        dist: `${portal_dist}/css/`,
        prefixerOptions: {
            browsers: ['last 2 versions', '> 5%', 'Firefox ESR']
        }
    },
    js: {
        dist: `${portal_dist}/js`,
        watch: `${portal_src}/js/**/*.js`,
        files: [{
                outputFileName: "bundle.js",
                es6: false,
                inputFiles: [
                    './node_modules/jquery/dist/jquery.min.js',
                    './node_modules/bootstrap/dist/js/bootstrap.bundle.min.js',
                    `${portal_src}/js/vendor/affix.js`,
                    `${portal_src}/js/vendor/jquery.appear.js`,
                    `${portal_src}/js/vendor/jquery.easing.1.3.js`,
                    `${portal_src}/js/vendor/jquery.hoverIntent.js`,
                    `${portal_src}/js/vendor/superfish.js`,
                ],
            },
            {
                outputFileName: "script.js",
                es6: true,
                inputFiles: [
                    `${portal_src}/js/scripts.js`
                ],
            },{
                outputFileName: "home.js",
                es6: false,
                inputFiles: [
                    `${portal_src}/js/vendor/jquery.flexslider-min.js`,
                    `${portal_src}/js/vendor/owl.carousel.min.js`,
                    `${portal_src}/js/home.js`
                ],
            },
            {
                outputFileName: "contact.js",
                es6: true,
                inputFiles: [
                    './node_modules/jquery-validation/dist/jquery.validate.min.js',
                    './node_modules/jquery-validation/dist/additional-methods.js',
                    `${portal_src}/js/contact.js` 
                ],
            } ,
            {
                outputFileName: "gallery.js",
                es6: true,
                inputFiles: [
                    `${portal_src}/js/vendor/photoswipe.js`,
	                `${portal_src}/js/vendor/photoswipe-ui-default.min.js`,
                    `${portal_src}/js/gallery.js` 
                ],
            }  ,
            {
                outputFileName: "about.js",
                es6: true,
                inputFiles: [
                    `${portal_src}/js/vendor/owl.carousel.min.js`,
                    `${portal_src}/js/aboutus.js` 
                ],
            }  
        ]
    },
}