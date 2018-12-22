// default settings. fis3 release

fis.set('project.ignore', ['node_modules/**', 'output/**', '.git/**', 'fis-conf.js', 'package.json', 'js/loader.js']); // �ų�ĳЩ�ļ�, 'lib/**/*'
fis.match('::image', {
  useHash: true
});

//fis-conf.js
// ���ò��
fis.hook('relative');
// Global end

// default media is `dev`
fis.media('dev').match('*', {
    useHash: false,
    optimizer: null
});

//����ʱѹ��
fis.media('prod').match('**', {// �������ļ�����ʹ�����·����
    relative: true
}).match('*.css', {
    optimizer: fis.plugin('clean-css'), // css ѹ��
    rExt: '.min.css',//��׺
    useHash: false
}).match('*.js', {
    optimizer: fis.plugin('uglify-js'),//jsѹ��
    rExt: '.min.js',//��׺
    useHash: false,
}).match('*.png', {
    optimizer: fis.plugin('png-compressor'),// png ͼƬѹ��
    useHash: false
})
// extends GLOBAL config
//fis.media('production');