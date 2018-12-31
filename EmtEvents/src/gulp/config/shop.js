var shop_dist = "./wwwroot/shop";
var shop_src = "./src/shop";

module.exports = {
    dist: shop_dist,
    src: shop_src,
    header: '/*!\n* <%= pkg.name %> - v <%= pkg.version %> \n* <%= pkg.description %> \n* Author :<%= pkg.author %>\n*/\n',
    fonts : [
            {
                output : `${shop_dist}/fonts/fa/`,
                input : [
                    './node_modules/font-awesome/fonts/*',
                ]
            },{
                output : `${shop_dist}/fonts/`,
                input : [
                    `${shop_src}/fonts/**/*`
                ]
            }
    ],

    sassOptions: {
        outputStyle: 'compressed'
    },
    css: {
        src: [
           `${shop_src}/scss/**/*.scss`
        ],
        dist: `${shop_dist}/css/`,
        prefixerOptions: {
            browsers: ['last 2 versions', '> 5%', 'Firefox ESR']
        }
    },
    js : {
        dist: `${shop_dist}/js`,
        watch : `${shop_src}/js/**/*.js`,
        files :[
            {
                outputFileName : "bundle.js",
                es6 : false,
                inputFiles: [
                    './node_modules/jquery/dist/jquery.min.js',
                    './node_modules/bootstrap/dist/js/bootstrap.bundle.min.js',
                    './node_modules/bootstrap-notify/bootstrap-notify.min.js',
                    './node_modules/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.concat.min.js',
                ],
            },
            {
                outputFileName : "script.js",
                es6 : true,
                inputFiles: [
                     `${shop_src}/js/notification.js`,
                     `${shop_src}/js/productManage.js`,
                     `${shop_src}/js/scripts.js`

                ],
            },{
                outputFileName : "product.js",
                es6 : false,
                inputFiles: [
                   
                    './node_modules/lightslider/dist/js/lightslider.min.js',
                    `${shop_src}/js/product.js`
                ],
            },
            {
                outputFileName : "jquery-validate.js",
                es6 : false,
                inputFiles: [
                    './node_modules/jquery-validation/dist/jquery.validate.min.js',
                    './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js'
                ], 
            } 
        ]
    }
}