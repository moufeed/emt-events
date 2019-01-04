
const 
gulp = require('gulp'),
header = require('gulp-header'),
watch = require('gulp-watch'),
sass = require('gulp-sass')
concat = require('gulp-concat'),
rename = require('gulp-rename'),
autoprefixer = require('gulp-autoprefixer'),
uglify =  require('gulp-uglify-es').default, 
merge = require("merge-stream"),
babel = require('gulp-babel'),
pkg = require('../../../package.json'),
app= require("../../../appsettings.json"),
shop_config = require('../config/shop.config'),
mod = require('../lib/module')
;

//-------------------------------------------------
// --  shop style files 
//-------------------------------------------------
gulp.task('s:css', ()=> {
    return gulp.src(shop_config.css.src)
        .pipe(sass(shop_config.sassOptions).on('error', sass.logError))
        .pipe(rename({
            suffix: '.min'
        }))
        .pipe(header(shop_config.header, {
            pkg: pkg
        }))
        .pipe(autoprefixer(shop_config.css.prefixerOptions))
        .pipe(gulp.dest(shop_config.css.dist));
});
// ----------------------------------------------------
// -- shop javscript files
// ----------------------------------------------------
 
gulp.task("s:js",  ()=> {
    let tasks = mod.getBundles(mod.regex.js , shop_config.js.files).map( (file)=> {

        let  g = gulp.src(file.inputFiles, { base: "." })
                .pipe(concat(file.outputFileName));
            
                if(file.es6){
                    g.pipe(babel({
                        presets: [['env', { modules: false }]],
                    }))
                } 
                g.pipe(uglify({
                    mangle: true
                }))
                .pipe(rename({
                    suffix: '.min'
                }))
                .pipe(header(shop_config.header, {
                    pkg: pkg
                }))
                .pipe(gulp.dest(shop_config.js.dist));
            return g;
                    
         
        
    });
    return merge(tasks);
});

// ----------------------------------------------------
// -- shop fonts files
// ----------------------------------------------------

gulp.task('s:f', function() {

     let tasks = shop_config.fonts.map((folder)=>{
        return gulp.src(folder.input)
        .pipe(gulp.dest(folder.output))
     })
     
     return merge(tasks)
  })


// ----------------------------------------------------
// -- shop  watch files
// ----------------------------------------------------
gulp.task('s:w',  ()=> {
    gulp.watch(shop_config.js.watch, ['s:js']);
    gulp.watch(shop_config.css.src, ['s:css']);
});



